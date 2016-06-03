unsigned short ADC_VALUE;
byte _channelNumber;  //DEBUG

unsigned short _usNumberOfChannels=4;
String _sConfigData="GAIN=1";

bool _blIsInitialized;
bool _blReceivedInit;

unsigned short counter=0;

void setup() 
{
  Serial.begin(250000);
  _channelNumber=0;
  _blIsInitialized=false;
  _blReceivedInit=false;
  
  pinMode(13, OUTPUT);
  digitalWrite(13, LOW);
}

void loop() 
{

  
  
  if(!_blIsInitialized)
  {
    //look for software init
    if(Serial.available())
    {
      String readResult=Serial.readString();
      if(readResult=="INIT")
      {
       //read the initialization code "INIT"
       //send timestamp and config data
       _blReceivedInit=true;
       sendConfigMessage();
       
      }
      else if(readResult=="READY")
      {
        _blIsInitialized=true;
        digitalWrite(13, HIGH);
      }
    }
    else
    {
      if(_blReceivedInit)
      {
       // sendConfigMessage();
        
       // delay(1000);
      }
    }
  }


  
  if(_blIsInitialized)
  {
    //first process incoming message if one exists
    if(Serial.available())
    {




      
    }


    
    ADC_VALUE=random(0, (1<<12)-1);
    ADC_VALUE=0;

    //sendTimestamp();
    
    _channelNumber=0;
    sendADCMessage(_channelNumber, ADC_VALUE);

    if(_channelNumber<15) _channelNumber++;
    else _channelNumber=0;
  }
}

void sendADCSerialMessage(byte channelNumber, unsigned int adcValue)
{
  unsigned int twoByteMessage=(channelNumber<<12) + adcValue;
  Serial.write(twoByteMessage>>8);
  Serial.write(twoByteMessage);
}

void sendTimestamp()
{
  unsigned long timestamp=millis();
  timestamp=1;
  Serial.write(timestamp>>24);
  Serial.write(timestamp>>16);
  Serial.write(timestamp>>8);
  Serial.write(timestamp);
}

void sendADCMessage(unsigned short channelNumber, unsigned short adcValue)
{
  unsigned long timestamp=millis();
  
  channelNumber=0;
  unsigned short twoByteMessage=(channelNumber<<12) + adcValue;
  
  byte buf[9]={33, 33, 33, (byte) (timestamp>>24), (byte) (timestamp>>16), (byte) (timestamp>>8), (byte) (timestamp), (byte) (twoByteMessage)>>8, (byte) (twoByteMessage)};
  Serial.write(buf, 9);
}


void sendConfigMessage()
{
  byte buf[10]={33,33,33,255,4,255,123,123,(byte) (counter>>8),(byte) counter};
  counter++;
  Serial.write(buf, 10);

}

