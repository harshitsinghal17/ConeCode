import {Component, OnInit, ViewChild} from '@angular/core';
import {Product} from "./model/products";
import {ProductsService} from "./ProductService/products.service";
import {NgForm} from "@angular/forms";


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  categories: any;
  subcategories: any;
  title = 'AngularHttpRequest';
  allProducts:Product[]=[];
  isFetching:boolean=false;
  editMode:boolean=false;
  currentProductId:number;
  @ViewChild('productsForm') form:NgForm;
  constructor(private productService:ProductsService) {
  }

  ngOnInit()
  {
this.fetchProduct();
this.getCategories();
this.getSubCategories(1);
  }
  onProductsFetch()
  {
    this.fetchProduct();
  }

  getCategories() {
    this.productService.fetchCategories().subscribe(data => {
      this.categories = data;
      console.log(data);
    });
  }

  getSubCategories(event) {
    this.productService.fetchSubCategories(event.target.value).subscribe(data => {
      this.subcategories = data;
      console.log(data);
    });
  }

  onProductCreate(product:{id: number, code: string,name:string,quantity:number,price:number,description:string, subcategoryId: number, categoryId: number}) {
    if(!this.editMode)
    {
      product.id = 0;
    this.productService.createProduct(product);
    this.fetchProduct()
    }
    else
    {
      this.productService.updateProduct(product);
      this.fetchProduct()
    }
  }


  private fetchProduct()
  {
    this.isFetching=true;
this.productService.fetchProduct().subscribe((products : Product[])=>{
this.allProducts=products;
this.isFetching=false;
})
  }


  fetchProductByCategory(event)
  {
    this.isFetching=true;
    this.getSubCategories(event);
this.productService.fetchProductByCategory(event.target.value).subscribe((products : Product[])=>{
this.allProducts=products;
this.isFetching=false;
})
  }

  fetchProductBySubCategory(event)
  {
    this.isFetching=true;
this.productService.fetchProductBySubCategory(event.target.value).subscribe((products : Product[])=>{
this.allProducts=products;
this.isFetching=false;
})
  }

  onDeleteProduct(id:number) {

this.productService.deleteProduct(id);
this.fetchProduct();
  }


  onEditProduct(id: number) {
    this.currentProductId=id;
let currentProduct=this.allProducts.find((p)=>{return p.id ===id})
console.log(currentProduct);

this.form.setValue({
  id: currentProduct.id,
  code:currentProduct.code,
  name:currentProduct.name,
  quantity:currentProduct.quantity,
  price:currentProduct.price,
  description:currentProduct.description,
  categoryId: currentProduct.categoryId,
  subcategoryId: currentProduct.subCategoryId,
});
this.editMode=true;
}
}



