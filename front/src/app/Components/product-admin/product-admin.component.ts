import { Component, OnInit } from '@angular/core';
import { ProductService } from 'app/Services/product.service';
import { Product } from 'app/models/product';
import { ConfirmationService, MessageService } from 'primeng/api';
import { SelectItem } from 'primeng/api/selectitem';
import { map } from 'rxjs';

@Component({
  selector: 'app-product-admin',
  templateUrl: './product-admin.component.html',
  styleUrls: ['./product-admin.component.scss']
})
export class ProductAdminComponent implements OnInit {

  products : Product[];
  statuses: SelectItem[];
  productDialog: boolean = false;

  product!: Product;

  selectedProducts!: Product[] | null;

  submitted: boolean = false;
  clonedProducts: { [s: string]: Product; } = {};
  constructor(private _productService : ProductService, private messageService : MessageService, private confirmationService : ConfirmationService) { }

  ngOnInit() {
    this._productService.getProducts().subscribe( products => {
      this.products = products;
    })
    this.statuses = [
      { label: 'INSTOCK', value: 'INSTOCK' },
      { label: 'LOWSTOCK', value: 'LOWSTOCK' },
      { label: 'OUTOFSTOCK', value: 'OUTOFSTOCK' }
  ];
  }

  onRowEditInit(product: Product) {
    this.clonedProducts[product.id] = {...product};
}

  onRowEditSave(product: Product) {
      if (product.price > 0) {
          delete this.clonedProducts[product.id];
      }
  }

  onRowEditCancel(product: Product, index: number) {
      this.products[index] = this.clonedProducts[product.id];
      delete this.clonedProducts[product.id];

  }

  openNew() {
      this.product = new Product();
      this.submitted = false;
      this.productDialog = true;
  }
  deleteSelectedProducts() {
    this.confirmationService.confirm({
        message: 'Are you sure you want to delete the selected products?',
        header: 'Confirm',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
            this._productService.deleteProducts(this.selectedProducts).subscribe(res => {
              this.products= res;
            });
            this.selectedProducts = null;
            this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Products Deleted', life: 3000 });
        }
    });
  }

  deleteProduct(product: Product) {
    this.confirmationService.confirm({
        message: 'Are you sure you want to delete ' + product.name + '?',
        header: 'Confirm',
        icon: 'pi pi-exclamation-triangle',
        accept: () => {
            this._productService.deleteProduct(product.id).subscribe(res => {
              this.products= res;
            });
            this.product = new Product();
            this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Product Deleted', life: 3000 });
        }
    });
}

  editProduct(product: Product) {
      this.product = { ...product };
      this.productDialog = true;
  }


  hideDialog() {
      this.productDialog = false;
      this.submitted = false;
  }

  saveProduct() {
    this.submitted = true;

    if (this.product.name?.trim()) {
        if (this.product.id) {
            this.products[this.findIndexById(this.product.id)] = this.product;
            this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Product Updated', life: 3000 });
        } else {
            this.product.id = this.createId();
            this.product.image = 'product-placeholder.svg';
            this._productService.createProduct(this.product).subscribe(res => {
              this.products = res;
            })
            this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Product Created', life: 3000 });
        }

        this.products = [...this.products];
        this.productDialog = false;
        this.product = new Product();
    }
}

  findIndexById(id: number): number {
    let index: number;
  this._productService.findIndexById(id)
    .then(result => {
      index = result;
    })
  return index;
  }

  createId(): number {
      let id =1030;
      for (var i = 0; i < 50; i++) {
          id += (Math.floor(Math.random()*i));
      }
      return id;
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

