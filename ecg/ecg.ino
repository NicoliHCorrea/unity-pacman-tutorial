int min = 150;
int oldbeat = 0;
bool beat = false;
void setup() {
   Serial.begin(9600);
   pinMode(10, INPUT); // Configuração para detecção de derivações LO +
   pinMode(11, INPUT); // Configuração para detecção de leads off LO -
}

void BPM(){
  int newbeat =  millis();
  //Serial.println(newbeat);
  int diff = newbeat - oldbeat;
  //Serial.println(diff);
  float currentBPM = 60000/diff ;
  Serial.println(currentBPM);
  oldbeat = newbeat;
}
void loop() {
 
  if((digitalRead(10) == 1)||(digitalRead(11) == 1)){
     Serial.println('!');
  } else {
    // envia o valor da entrada analógica 0:
    int var = analogRead(A0);
    //Serial.println(var);
    if (var < min && beat == false){
      //Serial.println("batimento");
      BPM();
      beat = true;
    }
    if (var>min){
      beat = false;
    }
  
  //Serial.print(0); // To freeze the lower limit
  //Serial.print(" ");
  //Serial.print(1000); // To freeze the upper limit
  //Serial.print(" ");
  // Espere um pouco para evitar que os dados seriais saturem
  //delay(1);


  }

}
