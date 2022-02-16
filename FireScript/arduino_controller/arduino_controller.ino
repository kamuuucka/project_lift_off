#include <Keyboard.h>

const int buttonUp = 4;
const int buttonDown = 5;
const int buttonRight = 6;
const int buttonLeft = 3;
char keyUP = KEY_UP_ARROW;
char keyDOWN = KEY_DOWN_ARROW;
char keyLEFT = KEY_LEFT_ARROW;
char keyRIGHT = KEY_RIGHT_ARROW;
const int spaceButton = 8;
char keySPACE = ' ';

void setup() {
  pinMode(buttonUp, INPUT);
  pinMode(buttonDown, INPUT);
  pinMode(buttonRight, INPUT);
  pinMode(buttonLeft, INPUT);
  Keyboard.begin();
}

void loop() {
  if (digitalRead(buttonUp) == HIGH){
    Serial.print("W");
    Keyboard.press('w');
    delay(250);
    Keyboard.releaseAll();
  } 
  else if (digitalRead(buttonDown) == HIGH){
    Serial.print("S");
    Keyboard.press('s');
    delay(250);
    Keyboard.releaseAll();
  }
  else if (digitalRead(buttonRight) == HIGH){
    Serial.print("D");
    Keyboard.press('d');
    delay(250);
    Keyboard.releaseAll();
  }
  else if (digitalRead(buttonLeft) == HIGH){
    Serial.print("A");
    Keyboard.press('a');
    delay(250);
    Keyboard.releaseAll();
  }

    if (analogRead(0) > 900){
      Keyboard.press(keyDOWN);
      Serial.print("UPPP");
      Keyboard.releaseAll();
    } 
    else if (analogRead(0) < 300){
      Keyboard.press(keyUP);
      Keyboard.releaseAll();
    } 

    if (analogRead(1) > 900){
      Keyboard.press(keyRIGHT);
      Keyboard.releaseAll();
    } 
    else if (analogRead(1) < 400){
      Keyboard.press(keyLEFT);
      Keyboard.releaseAll();
    }

    if (digitalRead(spaceButton) == HIGH){
      Keyboard.press(' ');
      Keyboard.releaseAll();
    }
}
