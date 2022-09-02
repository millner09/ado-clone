import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { environment } from '../environments/environment';
// Import the module from the SDK
import { AuthModule } from '@auth0/auth0-angular';
import { AuthHttpInterceptor } from '@auth0/auth0-angular';

import { MatCardModule } from '@angular/material/card';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { WeatherComponent } from './weather/weather.component';
import { AuthButtonComponent } from './auth-button/auth-button.component';
import { ProfileComponent } from './profile/profile.component';

@NgModule({
  declarations: [
    AppComponent,
    WeatherComponent,
    AuthButtonComponent,
    ProfileComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatCardModule,
    // Import the module into the application, with configuration
    AuthModule.forRoot({
      domain: environment.auth0.domain,
      clientId: environment.auth0.clientId,
      redirectUri: window.location.origin,
      // The AuthHttpInterceptor configuration
      httpInterceptor: {
        allowedList: [
          // Attach access tokens to any calls to '/api' (exact match)
          '/api',

          // Attach access tokens to any calls that start with '/api/'
          '/api/*',

          // Match anything starting with /api/accounts, but also specify the audience and scope the attached
          // access token must have
          {
            uri: `${environment.apiUrl}/*`,
            tokenOptions: {
              audience: environment.auth0.audience,
            },
          },
        ],
      },
    }),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthHttpInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
