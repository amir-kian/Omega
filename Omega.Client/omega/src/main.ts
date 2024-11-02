import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { provideHttpClient } from '@angular/common/http'; // Import provideHttpClient

// Bootstrap the application with AppComponent and provide HttpClient
bootstrapApplication(AppComponent, {
  providers: [
    provideHttpClient() // Add this line to provide HttpClient
  ]
})
.catch((err) => console.error(err));
