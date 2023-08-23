import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-update',
  templateUrl: './product-update.component.html',
  styleUrls: ['./product-update.component.css']
})
export class ProductUpdateComponent implements OnInit {
  product: Product = {
    name: ''
  }

  constructor(
    private productService: ProductService, 
    private router: Router,
    private route: ActivatedRoute) 
    { }

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    const id = idParam !== null ? +idParam : 0;
    this.loadProductById(id);
  }

  updateProduct() : void {
    this.productService.update(this.product).subscribe(() => {
      this.productService.showMessage("Produto atualizado com sucesso!");
      this.router.navigate(['/products']);
    })
  }

  cancel() : void {
    this.router.navigate(['/products']);
  }

  loadProductById(id: number) : void {
    this.productService.getById(id).subscribe(response => {
      this.product = response.result
    })
  }
}
