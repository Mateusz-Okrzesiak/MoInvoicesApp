import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Config } from 'protractor';
import { Invoice } from '../models/invoice.model';

@Injectable()
export class InvoiceService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  createInvoice( invoice: Invoice) {
    this.httpClient.post<Invoice>(this.baseUrl + 'invoice', invoice).subscribe();
  }
}
