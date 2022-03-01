import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/models/brands';
import { IPagination } from '../shared/models/pagination';
import { IProductTypes } from '../shared/models/productTypes';
import { map } from 'rxjs/operators';
import { shopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';
  constructor(private http: HttpClient) {}
  getProducts(shopParams: shopParams) {
    let params = new HttpParams();
    if (shopParams.brandId !== 0) {
      params = params.append('brandId', shopParams.brandId.toString());
    }
    if (shopParams.typeId !== 0) {
      params = params.append('typeId', shopParams.typeId.toString());
    }

    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());
    if (shopParams.searchTerm) {
      params = params.append('search', shopParams.searchTerm.toString());
    }
    return this.http
      .get<IPagination>(this.baseUrl + 'Product', {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          return response.body;
        })
      );
  }
  getProductBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'Product/brands');
  }
  getProductTypes() {
    return this.http.get<IProductTypes[]>(this.baseUrl + 'Product/types');
  }
}
