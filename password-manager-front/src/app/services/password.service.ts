import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PasswordService {
  private apiUrl = 'https://localhost:7129';
  private apiKey = 'MyMegaSupraSuperSecretApiKey123!';//clé API

  constructor(private http: HttpClient) {}

  getPasswords(): Observable<any[]> {
    const headers = new HttpHeaders().set('x-api-key', this.apiKey);
    return this.http.get<any[]>(`${this.apiUrl}/passwords`, { headers });
  }

  addPassword(password: any): Observable<any> {
    const headers = new HttpHeaders().set('x-api-key', this.apiKey);
    return this.http.post<any>(`${this.apiUrl}/passwords`, password, { headers });
  }

  deletePassword(id: number): Observable<void> {
    const headers = new HttpHeaders().set('x-api-key', this.apiKey);
    return this.http.delete<void>(`${this.apiUrl}/passwords/${id}`, { headers });
  }
}
