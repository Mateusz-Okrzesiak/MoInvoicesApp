import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Config } from 'protractor';
import { Invoice, InvoiceList } from '../models/invoice.model';

@Injectable()
export class InvoiceService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  createInvoice(invoice: Invoice) {
    invoice.userID = 1;
    this.httpClient.post<Invoice>(this.baseUrl + 'invoice', invoice).subscribe();
  }

  GetAllUserInvoices() {
    let userID = 1;
    return this.httpClient.get<InvoiceList[]>(this.baseUrl + `Invoice/AllUserInvoices/${userID}`);
  }
}
