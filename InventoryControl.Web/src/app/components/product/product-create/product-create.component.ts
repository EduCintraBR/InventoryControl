import { Component, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { Product } from '../product.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent implements OnInit {
  product: Product = {
    name: "Teste",
    price: 125.98
  }
  constructor(private productService: ProductService, 
              private snackBar: MatSnackBar,
              private router: Router) { }

  ngOnInit(): void {
  }

  createProduct() : void {
    this.productService.create(this.product).subscribe(() => {
      this.showMessage("Produto cadastrado com sucesso!");
      this.router.navigate(['/products']);
    })
  }

  showMessage(mensagem: string) : void {
    this.snackBar.open(mensagem, 'x', {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top"
    })
  }
}
