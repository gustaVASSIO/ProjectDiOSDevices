import Susbscription from "./subscription.model"

export interface Device{
   deviceId :  string 
   name :  string 
   description :  string 
   fotoPath? :  string 
   documentPath? :  string
   subscriptions : Susbscription[] 
}

export interface DeviceFiles{
   foto : File
   document : File
}