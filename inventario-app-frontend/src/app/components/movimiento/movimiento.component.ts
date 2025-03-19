import { Component } from '@angular/core';
import { ProductoService } from '../../services/producto.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-movimiento',
  templateUrl: './movimiento.component.html',
  standalone: true,  // ✅ Es un componente standalone
  imports: [CommonModule, FormsModule, MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatCardModule,] // ✅ Se agregan los módulos necesarios
})
export class MovimientoComponent {
  productoId!: number;
  cantidad!: number;
  mensaje = '';

  constructor(private productoService: ProductoService, private router: Router) { }

  registrarMovimiento(): void {
    const movimiento = { productoId: this.productoId, cantidad: this.cantidad };
    this.productoService.registrarMovimiento(movimiento).subscribe(() => {
      this.mensaje = 'Movimiento registrado con éxito';
    });
  }

  regresar() {
    this.router.navigate(['/inventario']); // ✅
  }
}
