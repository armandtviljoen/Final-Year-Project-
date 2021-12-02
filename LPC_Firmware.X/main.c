/*
 * File     :   LPC_Fimware.c
 * Author   :   Armandt Viljoen
 * Student  :   30257506
 * Created  :   August 2021
 */
#include "p24FJ64GA002.h"
#include "ezbl.h"
#include "xc.h"
#include <stdio.h>
#include <string.h>

#define FP 4000000
#define BAUDRATE 9600
#define BRGVAL ((FP/BAUDRATE)/16)-1
char    ReceivedChar;
int     TimingBit       = 0;                                                    // Controls Step Signals.
int     Count           = 0;
int     Command      = 0;
                        
int stepscaler= 200; int crank_dist = 1600;
 

#define X_MotorsStep        PORTBbits.RB14                                          
#define Y_MotorsStep        PORTBbits.RB13                                                                       
#define DIR                 PORTBbits.RB12   
#define Crank_MotorsStep    PORTBbits.RB9    
#define Crank_Dir           PORTBbits.RB8 

#define LED_PWR             PORTBbits.RB15
#define LED_S1              PORTBbits.RB7
#define LED_S2              PORTBbits.RB6

#define DELAY_105uS asm volatile ("REPEAT, #420"); Nop(); // 105uS delay

int main(void)
{
//******************************************************************************
// Timer 2
T2CON           = 0x08020;                  //Stops and reset control register
TMR2            = 0;                        //Clear timer register
PR2             = 15;                       //0.25 millisecond delay
IPC1bits.T2IP   = 4;                        //Timer2 interrupt priority level
IFS0bits.T2IF   = 0;                        //Clear Timer2 interrupt status flag
IEC0bits.T2IE   = 1;                        //Enable Timer2 interrupts
T2CONbits.TGATE = 0;                        //Set Timer2 for operation in Gated
T2CONbits.TON   = 1;                        //Start Timer2

//******************************************************************************   
// Serial Communication
    RPOR5bits.RP11R = 3;                        // configure U1TX to RP11
    RPINR18bits.U1RXR =10;

    U1MODEbits.STSEL    = 0;                    // 1-Stop bit
    U1MODEbits.PDSEL    = 1;                    // Even Parity, 8-Data bits
    U1MODEbits.ABAUD    = 0;                    // Auto-Baud disabled
    U1MODEbits.BRGH     = 0;                    // Standard-Speed mode
    U1BRG               = BRGVAL;               // Baud Rate setting for 9600
    U1STAbits.UTXISEL0  = 0;                    // Interrupt after one TX
    U1STAbits.UTXISEL1  = 0;

    IEC0bits.U1TXIE     = 1;                    // Enable UART TX interrupt
    IPC3bits.U1TXIP     = 4;
    IFS0bits.U1RXIF     = 0;

    U1MODEbits.UARTEN   = 1;                    // Enable UART
    U1STAbits.UTXEN     = 1;                    // Enable UART TX

//******************************************************************************
//Motor control signals and rotational directions:
    LATBbits.LATB15     = 0;  
    TRISBbits.TRISB15   = 0; 
    TRISBbits.TRISB15   = 1; 
    
    LATBbits.LATB14     = 0;  
    TRISBbits.TRISB14   = 0; 
    
    LATBbits.LATB13     = 0;  
    TRISBbits.TRISB13   = 0;

    LATBbits.LATB12      = 0;  
    TRISBbits.TRISB12    = 0;
    
    LATBbits.LATB9      = 0;  
    TRISBbits.TRISB9    = 0;
   
    LATBbits.LATB8      = 0;  
    TRISBbits.TRISB8    = 0;
    
    LATBbits.LATB7      = 0;  
    TRISBbits.TRISB7    = 0;
    
    LATBbits.LATB6      = 0;  
    TRISBbits.TRISB6    = 0;                        
     
//******************************************************************************    
    X_MotorsStep        = 0;
    Y_MotorsStep        = 0;
    DIR                 = 1; 
    Crank_Dir           = 1;
    LED_PWR             = 1;
    Crank_MotorsStep    = 0;
 
    DELAY_105uS
//******************************************************************************       
 while(1){
    LED_S1             = 1;
    LED_S2             = 1; 
    if(U1STAbits.FERR == 1){                    // Check for receive errors
        continue;
    }
    
    if(U1STAbits.OERR == 1){                    // Must clear the overrun error
        U1STAbits.OERR = 0;
        continue;
    }
    
    if(U1STAbits.URXDA == 1){                   // Get the data
        ReceivedChar = U1RXREG; 
        U1TXREG = ReceivedChar;         
    } 
//******************************************************************************
// Command Identification.
    DELAY_105uS
        if(ReceivedChar == '0'){                // Stop all motors
            Count               = 0;
            Command             = 0;
            Crank_MotorsStep    = 0;
            X_MotorsStep        = 0;
            Y_MotorsStep        = 0;
        }
        if(ReceivedChar == '1'){                //Step motor: Increase X 
            Count               = 0;
            Command             = 1;
        }
        if(ReceivedChar == '2'){                //Step motor: Increase Y
            Count               = 0;
            Command = 2;   
        }        
        if(ReceivedChar == '3'){                //Step motor: Decrease X
            Count               = 0;  
            Command             = 3;
        }
        if(ReceivedChar == '4'){                //Step motor: Decrease Y
            Count               = 0; 
            Command             = 4;
        } 
        if(ReceivedChar == '5'){                //Step motor: Crank(partial)                 
            Count               = 0;
            Command             = 5;
        }
        if(ReceivedChar == '6'){                //Step motor: Crank(full forward) 
            Count               = 0;
            Command             = 6;
        } 
        if(ReceivedChar == '7'){                //Step motor: Crank(full reverse)
            Count               = 0;
            Command             = 7;
        } 
  }
}
//****************************************************************************** 


//******************************************************************************
void __attribute__((__interrupt__, auto_psv)) _U1TXInterrupt(void){
    IFS0bits.U1TXIF = 0;                        // Clear TX Interrupt flag
}
//******************************************************************************


//******************************************************************************
  void __attribute__((__interrupt__, auto_psv)) _T2Interrupt(void){   
// Increase position in X_Direction.  
      if((Command == 1 )&&(Count <= stepscaler)){
        DIR                 = 1;
        if (TimingBit == 1){
            X_MotorsStep    = 0;                                                   
            TimingBit       = 0;
        }else { 
            X_MotorsStep    = 1;                                                    
            TimingBit       = 1;  
        }
        Count++;  
        if(Count == stepscaler){
            Command         = 0;
            X_MotorsStep    = 0; 
            TimingBit       = 0;
            ReceivedChar    = '0';
        }
     }
 
// Increase position in Y_Direction.  
      if((Command == 2 )&&(Count <= stepscaler)){
        DIR                 = 1;
        if (TimingBit == 1){
            Y_MotorsStep    = 0;                                                   
            TimingBit       = 0;
        }else { 
            Y_MotorsStep    = 1;                                                    
            TimingBit       = 1;  
        }
        Count++;  
        if(Count == stepscaler){
            Command         = 0;
            Y_MotorsStep    = 0; 
            TimingBit       = 0;
            ReceivedChar    = '0';
        }
     }
 
 // Decrease position in X_Direction.

      if((Command == 3 )&&(Count <= stepscaler)){
        DIR                 = 0;
        if (TimingBit == 1){
            X_MotorsStep    = 0;                                                   
            TimingBit       = 0;
        }else { 
            X_MotorsStep    = 1;                                                    
            TimingBit       = 1;  
        }
        Count++;  
        if(Count == stepscaler){
            Command         = 0;
            X_MotorsStep    = 0; 
            TimingBit       = 0;
            ReceivedChar    = '0';
        }
     }
 
// Decrease position in Y_Direction.  
      if((Command == 4 )&&(Count <= stepscaler)){
        DIR                 = 0;         
        if (TimingBit == 1){
            Y_MotorsStep    = 0;                                                   
            TimingBit       = 0;
        }else { 
            Y_MotorsStep    = 1;                                                    
            TimingBit       = 1;  
        }
        Count++;  
        if(Count == stepscaler){
            Command         = 0;
            Y_MotorsStep    = 0; 
            TimingBit       = 0;
            ReceivedChar    = '0';
        }
     }

// Rotate crank 10% Degrees.  
      if((Command == 5 )&&(Count <= 160)){
        Crank_Dir               = 1;  
        if (TimingBit == 1){
            Crank_MotorsStep    = 0;                                                   
            TimingBit           = 0;
        }else { 
            Crank_MotorsStep    = 1;                                                    
            TimingBit           = 1;  
        }
        Count++;  
        if(Count == 160){
            Command             = 0;
            Crank_MotorsStep    = 0; 
            TimingBit           = 0;
            ReceivedChar        = '0';
        }
     }
      // Rotate crank 360 Degrees Forward.  
      if((Command == 6 )&&(Count <= crank_dist)){
        Crank_Dir               = 1;      
        if (TimingBit == 1){
            Crank_MotorsStep    = 0;                                                   
            TimingBit           = 0;
        }else { 
            Crank_MotorsStep    = 1;                                                    
            TimingBit           = 1;  
        }
        Count++;  
        if(Count == crank_dist) {
            Command             = 0;
            Crank_MotorsStep    = 0; 
            TimingBit           = 0;
            ReceivedChar        = '0';
        }
     }
      // Rotate crank 360 Degrees Reverse.  
      if((Command == 7 )&&(Count <= crank_dist)){
        Crank_Dir               = 0;     
        if (TimingBit == 1){
            Crank_MotorsStep    = 0;                                                   
            TimingBit           = 0;
        }else { 
            Crank_MotorsStep    = 1;                                                    
            TimingBit           = 1;  
        }
        Count++;  
        if(Count == crank_dist) {
            Command             = 0;
            Crank_MotorsStep    = 0; 
            TimingBit           = 0;
            ReceivedChar        = '0';
        }
     }
      
//Reset Timer.     
TMR2 = 0xEAA2;                         // Clear contents of the timer register                     
IFS0bits.T2IF = 0;                     // Reset the interrupt flag     
  }
//******************************************************************************