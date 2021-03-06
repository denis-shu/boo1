import { Product } from './../../models/product';
import { ProductService } from './../../product.service';
import { Component, OnInit } from '@angular/core';
import { OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { DataTableResource } from 'angular-4-data-table';

@Component({
  selector: 'app-admin-products',
  templateUrl: './admin-products.component.html',
  styleUrls: ['./admin-products.component.css']
})
export class AdminProductsComponent implements OnInit, OnDestroy {
  products: Product[];
  filteredProducts: any[];
  subsc: Subscription;
  tableResource: DataTableResource<Product>;
  items: Product[];
  itemCount: number;

  constructor(private productService: ProductService) {
    this.subsc = this.productService.getAll().subscribe(products => {
      this.filteredProducts = this.products = products;
      this.initializeTable(products);
    });
  }

  private initializeTable(products: Product[]) {
    this.tableResource = new DataTableResource(products);
    this.tableResource.query({ offset: 0 }).then(items => this.items = items);
    this.tableResource.count().then(
      count => this.itemCount = count);

  }

  private reloadItems(params) {
    // tslint:disable-next-line:curly
    if (!this.tableResource) return;
    this.tableResource.query(params).then(items => this.items = items);
  }

  filter(query: string) {
    this.filteredProducts = (query) ?
      this.products.filter(p => p.title.toLowerCase().includes(query.toLowerCase()))
      : this.products;
  }

  ngOnInit() {
  }

  ngOnDestroy() {
    this.subsc.unsubscribe();
  }
}
