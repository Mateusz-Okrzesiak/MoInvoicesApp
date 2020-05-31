import { Component, OnInit, ViewChild } from '@angular/core';
import { Invoice } from 'src/app/models/invoice.model';
import { DocumentType } from 'src/app/interfaces/documentType';
import { InvoiceService } from 'src/app/services/invoice.service';
import { Router, ActivatedRoute } from '@angular/router';
import { MatTable } from '@angular/material';
import { InvoiceRowService } from 'src/app/interfaces/InvoiceRowService';

@Component({
  selector: 'app-edit-invoice',
  templateUrl: './edit-invoice.component.html',
  styleUrls: ['./edit-invoice.component.scss']
})

export class EditInvoiceComponent implements OnInit {

  @ViewChild(MatTable) table: MatTable<any>;
  displayedColumns: string[] = ['serviceName', 'JM', 'quantity', 'netPrice', 'netWorth', 'vatRate', 'vatAmount', 'grossValue'];
  currentInvoice: Invoice = null;
  documentTypes: DocumentType[];

  constructor(private invoiceService: InvoiceService,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit() {
    this.invoiceService.getInvoice(+this.route.snapshot.paramMap.get('invoiceID')).subscribe(invoice => {
       this.currentInvoice = invoice;
      });
    this.invoiceService.getDocumentTypes().subscribe(dt => {
      this.documentTypes = dt;
    });
  }

  updateInvoice() {
    this.invoiceService.updateInvoice(this.currentInvoice);
  }

  addNewServicePosition() {
    this.currentInvoice.services.push({ invoiceID: this.currentInvoice.invoiceID, serviceName: '', JM: 'szt.', quantity: 1, netPrice: 0.00,
    netWorth: 0.00, vatRate: '23%', vatAmount: 0, grossValue: 0.00 , invoiceRowServiceID: -1});
    this.table.renderRows();
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
    this.currentInvoice.services.forEach(function(record) {
      sumGross += record.grossValue;
      sumNet += record.netWorth;
    });
    this.currentInvoice.sumGrossValue = sumGross;
    this.currentInvoice.sumNetValue = sumNet;
  }

}
