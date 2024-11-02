import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [ 
    
  ],
  imports: [ // Import necessary modules
    BrowserModule,
    HttpClientModule
  ],
  providers: [], // Add any providers here if needed
  bootstrap: []
})
export class AppModule {}
