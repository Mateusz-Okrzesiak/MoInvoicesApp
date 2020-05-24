import { Component, OnInit, ViewChild, ElementRef, Input } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { BehaviorSubject } from 'rxjs';
import { DecimalPipe } from '@angular/common';
import { element } from 'protractor';
import { newArray } from '@angular/compiler/src/util';
import { Service, Invoice, Contractor } from '../../models/invoice.model';



@Component({
  selector: 'app-new-invoice',
  templateUrl: './new-invoice.component.html',
  styleUrls: ['./new-invoice.component.scss']
})

export class NewInvoiceComponent implements OnInit {

  @ViewChild(MatTable) table: MatTable<any>;
  displayedColumns: string[] = ['serviceName', 'JM', 'quantity', 'netPrice', 'netWorth', 'vatRate', 'vatAmount', 'grossValue'];

  contractor: Contractor = {name: '', nip: '', city: '', postalCode: '', street: ''};
  vendor: Contractor = {name: '', nip: '', city: '', postalCode: '', street: ''};
  invoice: Invoice;

  constructor() { }

  ngOnInit(): void {
    this.invoice = new Invoice(-1, '', '', new Date(), new Date(), '', new Array(), this.contractor, this.vendor, false, 0.00, 0.00);
    this.invoice.service.push(EMPTY_ROW);
  }

  save() {

  }

  addNewServicePosition() {
    this.invoice.service.push({ serviceName: '', JM: 'szt.', quantity: 1, netPrice: 0.00,
    netWorth: 0.00, vatRate: '23%', vatAmount: 0, grossValue: 0.00 });
    this.table.renderRows();
  }

  updateServiceName(el: Service, serviceName: string) {
    el.serviceName = serviceName;
  }

  updateQuantity(el: Service, quantity: number) {
    el.quantity = quantity;
    el = this.recalculateService(el);
  }

  updateNetPrice(el: Service, netPrice: number) {
    el.netPrice = netPrice;
    el = this.recalculateService(el);
  }

  recalculateService(service: Service): Service {
    service.netWorth = service.netPrice * service.quantity;
    service.grossValue = service.netPrice * 1.23 * service.quantity;
    service.vatAmount = service.netPrice * 0.23 * service.quantity;

    this.recalculateInvoice();

    return service;
  }

  recalculateInvoice() {
    let sumGross = 0;
    let sumNet = 0;
    this.invoice.service.forEach(function(record) {
      sumGross += record.grossValue;
      sumNet = record.netWorth;
    });
    this.invoice.sumGrossValue = sumGross;
    this.invoice.sumNetValue = sumNet;
  }
}

const EMPTY_ROW: Service = { serviceName: '', JM: 'szt.', quantity: 1, netPrice: 0.00,
netWorth: 0.00, vatRate: '23%', vatAmount: 0, grossValue: 0.00 };



