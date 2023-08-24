import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product.model';
import { EMPTY, Observable, catchError, map } from 'rxjs';
import { ResponseApi } from '../models/responseApi.model';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = "https://localhost:7001/"

  constructor(private http: HttpClient, private snackBar: MatSnackBar,) { }

  create(product: Product) : Observable<Product> {
    return this.http.post<Product>(this.baseUrl + "api/products", product).pipe(
      map(obj => obj),
      catchError(error => this.errorHandler(error))
    );
  }

  getAll() : Observable<ResponseApi> {
    return this.http.get<ResponseApi>(this.baseUrl + "api/products").pipe(
      map(obj => obj),
      catchError(error => this.errorHandler(error))
    );
  }

  getById(id: number) : Observable<ResponseApi> {
    return this.http.get<ResponseApi>(this.baseUrl + "api/products/" + id).pipe(
      map(obj => obj),
      catchError(error => this.errorHandler(error))
    );
  }

  update(product: Product) : Observable<ResponseApi> {
    return this.http.put<ResponseApi>(this.baseUrl + "api/products/", product).pipe(
      map(obj => obj),
      catchError(error => this.errorHandler(error))
    );
  }

  delete(id: number) : Observable<ResponseApi> {
    return this.http.delete<ResponseApi>(this.baseUrl + "api/products/" + id).pipe(
      map(obj => obj),
      catchError(error => this.errorHandler(error))
    );
  }

  errorHandler(error: any) : Observable<any> {
    this.showMessage('Ocorreu um erro!', true);
    return EMPTY;
  }

  showMessage(mensagem: string, isError: boolean = false) : void {
    this.snackBar.open(mensagem, 'x', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top",
      panelClass: isError ? ['msg-error'] : ['msg-success']
    })
  }
}
