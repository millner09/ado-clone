import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
// Import the module from the SDK
import { AuthModule } from '@auth0/auth0-angular';

import { MatCardModule } from '@angular/material/card';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { WeatherComponent } from './weather/weather.component';
import { AuthButtonComponent } from './auth-button/auth-button.component';

@NgModule({
  declarations: [AppComponent, WeatherComponent, AuthButtonComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatCardModule,
    // Import the module into the application, with configuration
    AuthModule.forRoot({
      domain: 'millner.auth0.com',
      clientId: 'k4pavHGKY71S2MibLXJGsQGiTJ6MFtlO',
    }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
