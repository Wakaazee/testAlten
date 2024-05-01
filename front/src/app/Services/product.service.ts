import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from 'app/models/product';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private _apiUrl = "https://localhost:7202/Products"
  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this._apiUrl);
  }

  getProductById(id: number): Observable<Product> {
    const url = `${this._apiUrl}/${id}`;
    return this.http.get<Product>(url);
  }

  createProduct(product: Product): Observable<Product[]> {
    return this.http.post<Product[]>(this._apiUrl, product);
  }

  updateProduct(id: number, product: Product): Observable<Product[]> {
    const url = `${this._apiUrl}/${id}`;
    return this.http.patch<Product[]>(url, product);
  }

  deleteProducts(products: Product[]): Observable<Product[]> {
    const url = `${this._apiUrl}`;
    return this.http.delete<Product[]>(url, { body: products });
  }

  deleteProduct(id : number): Observable<Product[]> {
    const url = `${this._apiUrl}/${id}`;
    return this.http.delete<Product[]>(url);
  }

  async findIndexById(id: number): Promise<number> {
    const product = await this.getProductById(id).toPromise();
    return product ? product.id : -1;
    
  }
}
