import {Injectable} from "@angular/core";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Product} from "../model/products";
import {map} from "rxjs/operators";

@Injectable({providedIn:"root"})
export class ProductsService{
  constructor(private http:HttpClient) {
  }

  //Create a Product In Database
  createProduct(product){
    console.log(product);
    this.http.post('https://localhost:7230/api/Products',product)
      .subscribe((res)=>{
        console.log(res);
      })
  }

  //Fetch Product From Database
  fetchProduct(){
    return this.http.get('https://localhost:7230/api/Products');
  }

   //Fetch Product From Database
   fetchProductByCategory(categoryId){
    return this.http.get('https://localhost:7230/api/Products/GetProductByCategoryId/'+categoryId);
  }

   //Fetch Product From Database
   fetchProductBySubCategory(subCategoryId){
    return this.http.get('https://localhost:7230/api/Products/GetProductBySubCategoryId/'+subCategoryId);
  }
    //Fetch Product From Database
  fetchCategories(){
      return this.http.get('https://localhost:7230/api/Products/GetProductCategories');
    }

      //Fetch Product From Database
  fetchSubCategories(categoryId){
    return this.http.get('https://localhost:7230/api/Products/GetProductSubCategories/'+categoryId);
  }

  //Delete a  Product From Database
  deleteProduct(id:number){

    this.http.delete('https://localhost:7230/api/Products/'+id)
      .subscribe();
  }

  updateProduct(value:Product){

    this.http.put('https://localhost:7230/api/Products',value)
      .subscribe();
  }
}

