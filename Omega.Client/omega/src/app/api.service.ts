import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'; // Import HttpHeaders
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root' // This allows the service to be provided globally
})
export class ApiService {
  private apiUrl = 'https://ebeheshtapi.tehran.ir/api/v1/Service/GetAllItems';

  constructor(private http: HttpClient) {} // Ensure HttpClient is injected here

  getAllItems(): Observable<any> {
    // Set the headers for the request
    const headers = new HttpHeaders({
      'Accept': 'application/json',
      'apikey': 'C85FC5A0-B8FB-4D65-AEE1-B956E3E1D186' // Include your API key here
    });

    // Perform the GET request with the specified headers
    return this.http.get<any>(this.apiUrl, { headers });
  }
}
