import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { InvoicesListComponent } from './components/Invoices/invoices-list/invoices-list.component';
import { CustomerComponent } from './components/customers/customer.component';
import { NewInvoiceComponent } from './components/Invoices/new-invoice/new-invoice.component';
import { EditInvoiceComponent } from './components/Invoices/edit-invoice/edit-invoice.component';
import { CustomersListComponent } from './components/customers/customers-list/customers-list.component';

const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'invoices-list', component: InvoicesListComponent },
    { path: 'customer-list', component: CustomersListComponent },
    { path: 'customer/edit/:customerID', component: CustomerComponent },
    { path: 'customer/add', component: CustomerComponent },
    { path: 'new-invoice', component: NewInvoiceComponent },
    { path: 'invoice/edit/:invoiceID', component: EditInvoiceComponent },

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
