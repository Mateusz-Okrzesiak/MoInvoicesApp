import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { InvoicesListComponent } from './components/Invoices/invoices-list/invoices-list.component';
import { CustomersComponent } from './components/customers/customers.component';
import { NewInvoiceComponent } from './components/Invoices/new-invoice/new-invoice.component';
import { homedir } from 'os';
import { EditInvoiceComponent } from './components/Invoices/edit-invoice/edit-invoice.component';

const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'invoices-list', component: InvoicesListComponent },
    { path: 'customer-list', component: CustomersComponent },
    { path: 'new-invoice', component: NewInvoiceComponent },
    { path: 'edit-invoice', component: EditInvoiceComponent },
    { path: 'home', component: HomeComponent }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
],
exports: [
    RouterModule
]
})

export class AppRoutingModule { }
