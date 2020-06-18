import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Invoice } from '../models/invoice.model';
import { Observable, throwError } from 'rxjs';
import { saveAs } from 'file-saver';

@Injectable()
export class PdfService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  generatePDF(invoice: Invoice): any {

  const mediaType = 'application/pdf';
    this.httpClient.post(this.baseUrl + 'pdf', invoice, { responseType: 'blob' }).subscribe(
      data => {
        const file = new Blob([data], {type: mediaType});
        const fileURL = URL.createObjectURL(file);
        window.open(fileURL);
      }
    );
  }
  
  generatePDFbyID(invoiceID: number): any {
    const mediaType = 'application/pdf';
    this.httpClient.get(this.baseUrl + `Pdf/${invoiceID}`, { responseType: 'blob'} ).subscribe(
      data => {
        const file = new Blob([data], {type: mediaType});
        const fileURL = URL.createObjectURL(file);
        window.open(fileURL);
      }
    );
  }

}
