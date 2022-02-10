#include <Keyboard.h>

const int buttonUp = 4;
const int buttonDown = 5;
const int buttonRight = 6;
const int buttonLeft = 3;

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
}
