// BLUETOOTH
#include <BLEDevice.h>
#include <BLEUtils.h>
#include <BLEServer.h>

// See the following for generating UUIDs:
// https://www.uuidgenerator.net/

#define SERVICE_UUID        "4fafc201-1fb5-459e-8fcc-c5c9c331914b"
#define CHARACTERISTIC_UUID "beb5483e-36e1-4688-b7f5-ea07361b26a8"

int led = D10;

// PUMPS
// pump 1
const int P1_inaPin = D8;
const int P1_inbPin = D9;

// pump 2
const int P2_inaPin = D4;
const int P2_inbPin = D5;

// pump 3
//const int P3_inaPin = D4;
//const int P3_inbPin = D2;


// comms
const byte numChars = 16;
char receivedChars[numChars];
char tempChars[numChars];        // temporary array for use when parsing
// variables to hold the parsed data
int trigger = 0;
int pumpNumber = 0;
int pumpTime = 0;

boolean newData = false;

unsigned long previousMillis = 0;
unsigned long currentMillis = 0;
unsigned long elapsedTime = 0;

class MyCallbacks: public BLECharacteristicCallbacks {
//    void onWrite(BLECharacteristic *pCharacteristic) {
//      std::string value = pCharacteristic->getValue();
//      int length = value.length();
//      if (length > 0) {
//        newData = true;
//        digitalWrite(led, HIGH);   // turn the LED on
//
//        //Serial.println("*********");
//        //Serial.print("New value: ");
//        for (int i = 0; i < length; i++) {
//          //Serial.print(value[i]);
//          receivedChars[i] = value[i];
//        }
//        //Serial.println();
//        //Serial.println("*********");
//
//      }
    void onWrite(BLECharacteristic *pCharacteristic) {
      std::string value = pCharacteristic->getValue();
      int length = value.length();
      if(length <= 0) {
        return;
      }
      newData = true;
      digitalWrite(led, HIGH);
      int crntNumChars = length <= (numChars - 1) ? length : (numChars - 1); // min(length, numChars - 1)
      strncpy(receivedChars, value.c_str(), crntNumChars);
      receivedChars[crntNumChars] = '\0';
    }
};

//============

void setup() {
  ////Serial.begin(115200);

  // Setup Bluetooth
  BLEDevice::init("StickSlipESP32");
  BLEServer *pServer = BLEDevice::createServer();

  BLEService *pService = pServer->createService(SERVICE_UUID);

  BLECharacteristic *pCharacteristic = pService->createCharacteristic(
                                         CHARACTERISTIC_UUID,
                                         BLECharacteristic::PROPERTY_READ |
                                         BLECharacteristic::PROPERTY_WRITE
                                       );

  pCharacteristic->setCallbacks(new MyCallbacks());

  pCharacteristic->setValue("Hello World");
  pService->start();

  BLEAdvertising *pAdvertising = pServer->getAdvertising();
  pAdvertising->start();

  pinMode(led, OUTPUT);

  // Setup Pumps
  // setup pump 1
  pinMode(P1_inaPin, OUTPUT);
  pinMode(P1_inbPin, OUTPUT);

  // setup pump 2
  pinMode(P2_inaPin, OUTPUT);
  pinMode(P2_inbPin, OUTPUT);

  // setup pump 3
  //pinMode(P3_inaPin, OUTPUT);
  //pinMode(P3_inbPin, OUTPUT);

}

//============

void loop() {
  if (newData == true) {
    strcpy(tempChars, receivedChars);
    // this temporary copy is necessary to protect the original data
    //   because strtok() used in parseData() replaces the commas with \0
    parseData();
    showParsedData();
    newData = false;
    digitalWrite(led, LOW);   // turn the LED off
    runPumps();
  }
}

//============

void runPumps() {
  //currentMillis = millis();
  //elapsedTime = currentMillis - previousMillis;
  ////Serial.println(elapsedTime);

  if (trigger == 0) {
    switch (abs(pumpNumber)) {
      case 1:
        if (pumpNumber < 0) {
          digitalWrite(P1_inbPin, HIGH);
          delay(pumpTime);
          digitalWrite(P1_inbPin, LOW);
        } else {
          digitalWrite(P1_inaPin, HIGH);
          delay(pumpTime);
          digitalWrite(P1_inaPin, LOW);
        }
        break;

      case 2:
        if (pumpNumber < 0) {
          digitalWrite(P2_inbPin, HIGH);
          delay(pumpTime);
          digitalWrite(P2_inbPin, LOW);
        } else {
          digitalWrite(P2_inaPin, HIGH);
          delay(pumpTime);
          digitalWrite(P2_inaPin, LOW);
        }
        break;

/*
      case 3:
        if (pumpNumber < 0) {
          digitalWrite(P3_inbPin, HIGH);
          delay(pumpTime);
          digitalWrite(P3_inbPin, LOW);
        } else {
          digitalWrite(P3_inaPin, HIGH);
          delay(pumpTime);
          digitalWrite(P3_inaPin, LOW);
        }
        break;
*/
      default:
        digitalWrite(P1_inaPin, LOW);
        digitalWrite(P1_inbPin, LOW);
        digitalWrite(P2_inaPin, LOW);
        digitalWrite(P2_inbPin, LOW);
        //digitalWrite(P3_inaPin, LOW);
        //digitalWrite(P3_inbPin, LOW);
        break;
    }
  }

  else if (trigger == 1) {
    switch (abs(pumpNumber)) {
      case 1:
        if (pumpTime == 0) {
          digitalWrite(P1_inaPin, LOW);
        } else {
          digitalWrite(P1_inaPin, HIGH);
        }
        break;

      case 2:
        if (pumpTime == 0) {
          digitalWrite(P2_inaPin, LOW);
        } else {
          digitalWrite(P2_inaPin, HIGH);
        }
        break;

/*      case 3:
        if (pumpTime == 0) {
          digitalWrite(P3_inaPin, LOW);
        } else {
          digitalWrite(P3_inaPin, HIGH);
        }
        break;
*/
      default:
        digitalWrite(P1_inaPin, LOW);
        digitalWrite(P1_inbPin, LOW);
        digitalWrite(P2_inaPin, LOW);
        digitalWrite(P2_inbPin, LOW);
        //digitalWrite(P3_inaPin, LOW);
        //digitalWrite(P3_inbPin, LOW);
        break;
    }
  }
}


//============

void parseData() {      // split the data into its parts

  char * strtokIndx; // this is used by strtok() as an index

  strtokIndx = strtok(tempChars, ",");
  trigger = atoi(strtokIndx);

  strtokIndx = strtok(NULL, ",");
  pumpNumber = atoi(strtokIndx);

  strtokIndx = strtok(NULL, ","); // this continues where the previous call left off
  pumpTime = atoi(strtokIndx);     // convert this part to an integer

  //    strtokIndx = strtok(NULL, ","); // this continues where the previous call left off
  //    P2_pwm = atoi(strtokIndx);     // convert this part to an integer
  //
  //    strtokIndx = strtok(NULL, ","); // this continues where the previous call left off
  //    P2_time = atoi(strtokIndx);     // convert this part to an integer
  //
  //    strtokIndx = strtok(NULL, ","); // this continues where the previous call left off
  //    P3_pwm = atoi(strtokIndx);     // convert this part to an integer
  //
  //    strtokIndx = strtok(NULL, ","); // this continues where the previous call left off
  //    P3_time = atoi(strtokIndx);     // convert this part to an integer

}

//============

void showParsedData() {
  //Serial.print("mode: ");
  //Serial.println(trigger);
  //Serial.print("pump number: ");
  //Serial.println(pumpNumber);
  //Serial.print("pump time: ");
  //Serial.println(pumpTime);
  //    //Serial.print("P2_pwm ");
  //    //Serial.println(P2_pwm);
  //    //Serial.print("P2_time ");
  //    //Serial.println(P2_time);
  //    //Serial.print("P3_pwm ");
  //    //Serial.println(P3_pwm);
  //    //Serial.print("P3_time ");
  //    //Serial.println(P3_time);
}
