import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product.model';
import { Observable } from 'rxjs';
import { ResponseApi } from '../models/responseApi.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = "https://localhost:7001/"

  constructor(private http: HttpClient) { }

  create(product: Product) : Observable<Product> {
    return this.http.post<Product>(this.baseUrl + "api/products", product);
  }

  getAll() : Observable<ResponseApi> {
    return this.http.get<ResponseApi>(this.baseUrl + "api/products")
  }
}
