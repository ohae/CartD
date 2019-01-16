import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'page-about',
  templateUrl: 'about.html'
})
export class AboutPage {
  CartProducts: Product[];
  Products: ProductBase[];
  TotalAmount: number;
  Discount: number;
  GrandAmount: number;

  constructor(public navCtrl: NavController, public http: HttpClient) {
    this.GetCart();
    this.GetProducts();
  }

  ionViewDidEnter() {
    this.GetProducts();
  }

  AddProductToCart(itemid: string) {
    console.log(itemid);
    this.http.put<any>("https://localhost:44357/api/Cart",
      {
        quantity: 1,
        _id: itemid
      }).subscribe(
        it => {
          // SUCCESS: Do something
          this.GetCart();
          alert("Updated");
        },
        error => {
          // ERROR: Do something
        });
  }

  GetProducts() {

    this.http.get<any>("https://localhost:44357/api/Product").subscribe(
      it => {
        // SUCCESS: Do something
        this.Products = it.products;
      },
      error => {
        // ERROR: Do something
      });
  }

  GetCart() {

    this.http.get<any>("https://localhost:44357/api/Cart").subscribe(
      it => {
        // SUCCESS: Do something
        this.CartProducts = it.products;
        this.Discount = it.discount;
        this.TotalAmount = it.totalAmount;
        this.GrandAmount = it.grandAmount;
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
  public quantity: number;
}
export class ProductBase {
  public _id: string;
  public name: string;
  public price: number;
}