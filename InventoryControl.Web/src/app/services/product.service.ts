import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product.model';
import { Observable } from 'rxjs';
import { ResponseApi } from '../models/responseApi.model';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = "https://localhost:7001/"

  constructor(private http: HttpClient, private snackBar: MatSnackBar,) { }

  create(product: Product) : Observable<Product> {
    return this.http.post<Product>(this.baseUrl + "api/products", product);
  }

  getAll() : Observable<ResponseApi> {
    return this.http.get<ResponseApi>(this.baseUrl + "api/products")
  }

  getById(id: number) : Observable<ResponseApi> {
    return this.http.get<ResponseApi>(this.baseUrl + "api/products/" + id)
  }

  update(product: Product) : Observable<ResponseApi> {
    return this.http.put<ResponseApi>(this.baseUrl + "api/products/", product);
  }

  delete(id: number) : Observable<ResponseApi> {
    return this.http.delete<ResponseApi>(this.baseUrl + "api/products/" + id);
  }

  showMessage(mensagem: string) : void {
    this.snackBar.open(mensagem, 'x', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top"
    })
  }
}
