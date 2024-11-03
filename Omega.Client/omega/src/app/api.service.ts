import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
providedIn: 'root'
})
export class ApiService {
private baseUrl = 'https://ebeheshtapi.tehran.ir/api/v1/Service/';

constructor(private http: HttpClient) {}

getAllItems(): Observable<any> {
const headers = new HttpHeaders({
'Accept': 'application/json',
'apikey': 'C85FC5A0-B8FB-4D65-AEE1-B956E3E1D186'
});
return this.http.get<any>(`${this.baseUrl}/GetAllItems`, { headers });
}

getServiceDetails(serviceId: number): Observable<any> {
  const headers = new HttpHeaders({
    'Accept': 'application/json',
    'apikey': 'C85FC5A0-B8FB-4D65-AEE1-B956E3E1D186'
    });
return this.http.get<any>(`${this.baseUrl}/find/${serviceId}`);
}
}