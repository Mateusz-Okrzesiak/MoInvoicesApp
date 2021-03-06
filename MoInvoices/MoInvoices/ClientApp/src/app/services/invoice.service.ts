import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { DocumentType } from 'src/app/interfaces/documentType';
import { Invoice } from '../models/invoice.model';
import { InvoiceList } from '../interfaces/InvoiceList';
import { PaymentType } from '../interfaces/paymentType';
import { PaymentStatus } from '../interfaces/paymentStatus';

@Injectable()
export class InvoiceService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  createInvoice(invoice: Invoice) {
    invoice.userID = 1;
    return this.httpClient.post<Invoice>(this.baseUrl + 'invoice', invoice);
  }

  getInvoice(invoiceID: number) {
    return this.httpClient.get<Invoice>(this.baseUrl + `Invoice/${invoiceID}`);
  }

  deleteInvoice(invoiceID: number) {
    return this.httpClient.delete(this.baseUrl + `Invoice/${invoiceID}`);
  }

  updateInvoice(invoice: Invoice) {
    return this.httpClient.put(this.baseUrl + 'invoice', invoice);
  }

  getAllUserInvoices() {
    const userID = 1;
    return this.httpClient.get<InvoiceList[]>(this.baseUrl + `Invoice/AllUserInvoices/${userID}`);
  }

  // Metody uzupełniające Typy

  getDocumentTypes() {
    return this.httpClient.get<DocumentType[]>(this.baseUrl + `Invoice/DocumentTypes`);
  }

  getPaymentTypes() {
    return this.httpClient.get<PaymentType[]>(this.baseUrl + `Invoice/PaymentTypes`);
  }

  getPaymentStatuses() {
    return this.httpClient.get<PaymentStatus[]>(this.baseUrl + `Invoice/PaymentStatuses`);
  }
}
