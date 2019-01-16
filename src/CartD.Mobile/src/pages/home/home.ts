import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  Products: Product[];
  Name: string;
  Price: number;

  constructor(public navCtrl: NavController, public http: HttpClient) {
    this.GetProducts();
  }

  GetProducts()
  {

    this.http.get<any>("https://localhost:44357/api/Product").subscribe(
      it => {
        // SUCCESS: Do something
        this.Products = it.products;
      },
      error => {
        // ERROR: Do something
      });
  }

  AddProduct() {
    this.http.post<any>("https://localhost:44357/api/Product",
    {
      name: this.Name,
      price: this.Price
    }).subscribe(
        it => {
        // SUCCESS: Do something
    this.GetProducts();
    alert("created");
        }, 
        error => {
            // ERROR: Do something
        });
  }
}
export class Product {
  public _id: string;
  public name: string;
  public price: number;
}
