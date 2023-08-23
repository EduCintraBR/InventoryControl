import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { Product } from '../../../models/product.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent implements OnInit {
  product: Product = {
    name: ''
  }
  constructor(private productService: ProductService, 
              private router: Router) { }

  ngOnInit(): void {
  }

  createProduct() : void {
    this.productService.create(this.product).subscribe(() => {
      this.productService.showMessage("Produto cadastrado com sucesso!");
      this.router.navigate(['/products']);
    })
  }

  cancel() : void {
    this.router.navigate(['/products']);
  }
}
