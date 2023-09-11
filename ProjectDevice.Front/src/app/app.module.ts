import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { MaterialModule } from './matarial/material.module';
import { DevicesPrincipalScreenComponent } from './views/pages/devices-principal-screen/devices-principal-screen.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { DetailsDeviceComponent } from './views/pages/details-device/details-device.component';

@NgModule({
  declarations: [
    AppComponent,
    DevicesPrincipalScreenComponent,
    DetailsDeviceComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
