import { Component, OnInit, ViewChild, ElementRef, Input } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { BehaviorSubject } from 'rxjs';
import { Invoice } from '../../../models/invoice.model';
import { DocumentType } from 'src/app/interfaces/documentType';
import { InvoiceService } from 'src/app/services/invoice.service';
import { Router } from '@angular/router';
import { Contractor } from 'src/app/interfaces/contractor';
import { InvoiceRowService } from 'src/app/interfaces/InvoiceRowService';
import { PaymentType } from 'src/app/interfaces/paymentType';
import { PaymentStatus } from 'src/app/interfaces/paymentStatus';
import { PdfService } from 'src/app/services/pdf.service';
import { FormGroup, NgForm } from '@angular/forms';

@Component({
  selector: 'app-new-invoice',
  templateUrl: './new-invoice.component.html',
  styleUrls: ['./new-invoice.component.scss']
})

export class NewInvoiceComponent implements OnInit {

  @ViewChild(MatTable) table: MatTable<any>;
  displayedColumns: string[] = ['delete', 'serviceName', 'JM', 'quantity', 'netPrice', 'netWorth', 'vatRate', 'vatAmount', 'grossValue'];
  invoiceForm: FormGroup;
  
  contractor: Contractor = { name: '', nip: '', city: '', postalCode: '', street: ''};
  vendor: Contractor = { name: '', nip: '', city: '', postalCode: '', street: ''};
  invoice: Invoice;
  documentTypes: DocumentType[];
  paymentStatuses: PaymentStatus[];
  paymentTypes: PaymentType[];

  constructor(private invoiceService: InvoiceService, private router: Router,
              private pdfService: PdfService) { }

  ngOnInit(): void {
    this.InitForm();
  }

  InitForm() {
    this.invoice = new Invoice( -1, '', new Date(), new Date(), '',
                               new Array(), this.contractor, this.vendor, false, 0.00, 0.00, 1, '0', 1);
    this.invoice.services.push(EMPTY_ROW);
    this.invoiceService.getDocumentTypes().subscribe(dt => {
      this.documentTypes = dt;
    });
    this.invoiceService.getPaymentStatuses().subscribe(ps => {
      this.paymentStatuses = ps;
    });
    this.invoiceService.getPaymentTypes().subscribe(pt => {
      this.paymentTypes = pt;
    });
  }

  createInvoice(form: NgForm) {
    this.invoiceService.createInvoice(this.invoice);
    this.router.navigateByUrl('/invoices-list');
  }

  createPDF() {
    this.pdfService.generatePDF(this.invoice);
  }

  addNewServicePosition() {
    this.invoice.services.push({ serviceName: '', JM: 'szt.', quantity: 1, netPrice: 0.00,
    netWorth: 0.00, vatRate: '23%', vatAmount: 0, grossValue: 0.00 });
    this.table.renderRows();
  }

  removeServicePosition(index: number) {
    this.invoice.services.splice(index, 1);
    this.table.renderRows();
    this.recalculateInvoice();
  }

  updateServiceName(el: InvoiceRowService, serviceName: string) {
    el.serviceName = serviceName;
  }

  updateQuantity(el: InvoiceRowService, quantity: number) {
    el.quantity = +quantity;
    el = this.recalculateService(el);
  }

  updateNetPrice(el: InvoiceRowService, netPrice: number) {

    el.netPrice = +netPrice;
    el = this.recalculateService(el);
  }

  recalculateService(service: InvoiceRowService): InvoiceRowService {
    service.netWorth = service.netPrice * service.quantity;
    service.grossValue = service.netPrice * 1.23 * service.quantity;
    service.vatAmount = service.netPrice * 0.23 * service.quantity;

    this.recalculateInvoice();

    return service;
  }

  recalculateInvoice() {
    let sumGross = 0;
    let sumNet = 0;
    this.invoice.services.forEach(function(record) {
      sumGross += record.grossValue;
      sumNet += record.netWorth;
    });
    this.invoice.sumGrossValue = sumGross;
    this.invoice.sumNetValue = sumNet;
  }
}

const EMPTY_ROW: InvoiceRowService = { serviceName: '', JM: 'szt.', quantity: 1, netPrice: 0.00,
netWorth: 0.00, vatRate: '23%', vatAmount: 0, grossValue: 0.00 };



