export interface Device{
   deviceId :  string 
   name :  string 
   description :  string 
   fotoPath? :  string 
   documentPath? :  string 
}

export interface DeviceFiles{
   foto : File
   document : File
}