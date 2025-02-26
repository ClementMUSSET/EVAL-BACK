import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {
  private apiUrl = 'https://localhost:7129';
  private apiKey = 'MyMegaSupraSuperSecretApiKey123!'; //clé API

  constructor(private http: HttpClient) {}

  getApplications(): Observable<any[]> {
    const headers = new HttpHeaders().set('x-api-key', this.apiKey);
    return this.http.get<any[]>(`${this.apiUrl}/applications`, { headers });
  }
}
