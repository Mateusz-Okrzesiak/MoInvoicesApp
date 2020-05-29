import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule , ReactiveFormsModule} from '@angular/forms';
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
  MatToolbarRow,
  MatGridList,
  MatGridListModule
} from '@angular/material';
import { AppRoutingModule } from './app-routing.module';
import { InvoicesListComponent } from './components/Invoices/invoices-list/invoices-list.component';
import { NewInvoiceComponent } from './components/Invoices/new-invoice/new-invoice.component';
import { CustomersComponent } from './components/customers/customers.component';
import { InvoiceService } from './services/invoice.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    NewInvoiceComponent,
    InvoicesListComponent,
    CustomersComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
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
    HttpClientModule
  ], exports: [
    MatButtonModule,
    MatMenuModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
  ],
  providers: [InvoiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
