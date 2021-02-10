 #include "Keyboard.h"

//set all datapins
//player 1
const int buttonPin = 2;
//player2
const int buttonPin2 = 3;
//start button
const int buttonPinStart= 12;

//set all initial button states
//player1
int buttonState = 0;                                  
//player2
int buttonState2 = 0;
//start button
int buttonStateStart = 0;

//set bools to track if button was pressed (make sure you can't keep pushing button and printing character)
//player1
bool pressed = false;
//player2
bool pressed2 = false;
//start button
bool pressedStart = false;


void setup() {
  //set pinmode for all pins 
  //player1
  pinMode(buttonPin, INPUT_PULLUP);
  //player2
  pinMode(buttonPin2, INPUT_PULLUP);
  //start button
  pinMode(buttonPinStart, INPUT_PULLUP);

  //put all pins to high to get started
  //player1
  digitalWrite(buttonPin, HIGH);
  //player2
  digitalWrite(buttonPin2, HIGH);
  //start button
  digitalWrite(buttonPinStart, HIGH);

  //start keyboard simulation
  Keyboard.begin();
}

void loop() {

  //start button
  //read state of button
  buttonStateStart = digitalRead(buttonPinStart);
  //if button state is high, and the button isn't pressed yet press right key on keyboard
  if (buttonStateStart == HIGH && pressedStart == false) {
    Keyboard.press(32); 
    delay(10);
    Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
    pressedStart = true;
  }
  //if the button is low put pressed back to false because button has been released
  if(buttonStateStart == LOW) {
    pressedStart = false;
    delay(10);
  }

  //player1
  buttonState = digitalRead(buttonPin);
  if (buttonState == HIGH && pressed == false) {
    Keyboard.press('k');
    delay(10);
    Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
    pressed = true;
  }
  if(buttonState == LOW) {
    pressed = false;
    delay(10);
  }

  //player2
  buttonState2 = digitalRead(buttonPin2);
  if (buttonState2 == HIGH && pressed2 == false) {
    Keyboard.press('l');
    delay(10);
    Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
    pressed2 = true;
  }
  if(buttonState2 == LOW) {
    pressed2 = false;
    delay(10);
  }
}
