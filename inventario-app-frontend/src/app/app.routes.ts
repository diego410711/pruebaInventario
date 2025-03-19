import { Routes } from '@angular/router';
import { InventarioComponent } from './components/inventario/inventario.component';
import { LoginComponent } from './components/login/login.component';
import { MovimientoComponent } from './components/movimiento/movimiento.component';

export const routes: Routes = [
    { path: '', component: LoginComponent },
    { path: 'inventario', component: InventarioComponent },
    { path: 'movimiento', component: MovimientoComponent },
];