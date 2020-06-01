import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { AppComponent } from './components/app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';

import {
  MatButtonModule,
  MatMenuModule,
  MatToolbarModule,
  MatIconModule,
  MatCardModule,
  MatFormFieldModule,
  MatInputModule,
  MatSelectModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatDialogModule,
  MatToolbarRow,
  MatGridList,
  MatGridListModule
} from '@angular/material';
import { AppRoutingModule } from './app-routing.module';
import { InvoicesListComponent } from './components/Invoices/invoices-list/invoices-list.component';
import { NewInvoiceComponent } from './components/Invoices/new-invoice/new-invoice.component';
import { CustomerComponent } from './components/customers/customer.component';
import { InvoiceService } from './services/invoice.service';
import { EditInvoiceComponent } from './components/Invoices/edit-invoice/edit-invoice.component';
import { CustomerService } from './services/customer.service';
import { CustomersListComponent } from './components/customers/customers-list/customers-list.component';
import { PdfService } from './services/pdf.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    NewInvoiceComponent,
    InvoicesListComponent,
    CustomerComponent,
    CustomersListComponent,
    EditInvoiceComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    MatButtonModule,
    MatMenuModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
    AppRoutingModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    BrowserAnimationsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatGridListModule,
    MatTableModule,
    MatDialogModule,
    HttpClientModule
  ], exports: [
    MatButtonModule,
    MatMenuModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
  ],
  providers: [InvoiceService, CustomerService, PdfService],
  bootstrap: [AppComponent]
})
export class AppModule { }
