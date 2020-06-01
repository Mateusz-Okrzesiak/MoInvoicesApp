import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Invoice } from '../models/invoice.model';
import { Observable, throwError } from 'rxjs';
import { saveAs } from 'file-saver';

@Injectable()
export class PdfService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  generatePDF(invoice: Invoice): any {
  // const httpOptions = {
  //   responseType: 'blob' as 'json',
  //   params: {invoice}
  // };
  const mediaType = 'application/pdf';
    this.httpClient.post(this.baseUrl + 'pdf', invoice, { responseType: 'blob' }).subscribe(
      data => {
        const file = new Blob([data], {type: 'application/pdf'});
        const fileURL = URL.createObjectURL(file);
        window.open(fileURL);
      }
    );
  }
}
