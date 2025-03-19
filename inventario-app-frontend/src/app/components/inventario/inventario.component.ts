import { Component, OnInit } from '@angular/core';
import { ProductoService } from '../../services/producto.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-inventario',
  templateUrl: './inventario.component.html',
  imports: [CommonModule, MatTableModule, MatButtonModule, MatIconModule], // ✅ Importar CommonModule aquí

})
export class InventarioComponent implements OnInit {
  productos: any[] = [];
  displayedColumns: string[] = ['id', 'nombre', 'cantidad'];

  constructor(private productoService: ProductoService, private router: Router) { }

  ngOnInit(): void {
    this.productoService.getInventario().subscribe((data) => {
      this.productos = data;
    });
  }

  irAMovimiento(): void {
    this.router.navigate(['/movimiento']); // ✅ Navega con ID
  }
}
