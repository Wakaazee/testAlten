import { Component, OnInit } from '@angular/core';
import { ProductService } from 'app/Services/product.service';
import { Product } from 'app/models/product';
import { SelectItem } from 'primeng/api/selectitem';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

    sortOptions: SelectItem[];

    sortKey: string;
    sortOrder: number;
    sortField: string;

    products!: Product[];

    constructor(private productService: ProductService) {}

    ngOnInit() {
      this.productService.getProducts().subscribe(res => {
        console.log("res", res)
        this.products = res;
      });

      this.sortOptions = [
        {label: 'Prix décroissant', value: '!price'},
        {label: 'Prix croissant', value: 'price'}
    ];
}

onSortChange(event) {
    let value = event.value;

    if (value.indexOf('!') === 0) {
        this.sortOrder = -1;
        this.sortField = value.substring(1, value.length);
    }
    else {
        this.sortOrder = 1;
        this.sortField = value;
    }
  
  }

  searchProduct(value) {
    this.products.some(res => res.name==value)
  }
  getSeverity(status: string):string {
    switch (status) {
        case 'INSTOCK':
            return 'success';
        case 'LOWSTOCK':
            return 'warning';
        case 'OUTOFSTOCK':
            return 'danger';
    }

  }
}
