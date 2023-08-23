import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Product } from "src/app/models/product.model";
import { ProductService } from "src/app/services/product.service";

@Component({
  selector: "app-product-delete",
  templateUrl: "./product-delete.component.html",
  styleUrls: ["./product-delete.component.css"],
})
export class ProductDeleteComponent implements OnInit {
  productId: number = 0
  product: Product = {
    name: "",
  };

  constructor(
    private productService: ProductService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    this.productId = idParam !== null ? +idParam : 0;
    this.loadProductById(this.productId);
  }

  loadProductById(id: number): void {
    this.productService.getById(id).subscribe((response) => {
      this.product = response.result;
    });
  }

  cancel(): void {
    this.router.navigate(["/products"]);
  }

  deleteProduct() {
    this.productService.delete(this.productId).subscribe(() => {
      this.productService.showMessage('Produto deletado com sucesso!');
      this.router.navigate(['/products']);
    })
  }
}
