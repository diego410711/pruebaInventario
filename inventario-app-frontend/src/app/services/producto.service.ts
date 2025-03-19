import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProductoService {
  private apiUrl = 'https://localhost:7236/productos';

  constructor(private http: HttpClient) { }

  getInventario(): Observable<any> {
    return this.http.get(`${this.apiUrl}/inventario`, this.getAuthHeaders());
  }

  registrarMovimiento(movimiento: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/movimiento`, movimiento, this.getAuthHeaders());
  }

  private getAuthHeaders() {
    const token = localStorage.getItem('token');
    return {
      headers: new HttpHeaders({
        Authorization: `Bearer ${token}`,
      }),
    };
  }
}
