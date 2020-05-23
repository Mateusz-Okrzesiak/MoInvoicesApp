import { Component, OnInit, ViewChild, ElementRef, Input } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { BehaviorSubject } from 'rxjs';
import { DecimalPipe } from '@angular/common';
import { element } from 'protractor';

@Component({
  selector: 'app-new-invoice',
  templateUrl: './new-invoice.component.html',
  styleUrls: ['./new-invoice.component.scss']
})


export class NewInvoiceComponent implements OnInit {



  @ViewChild(MatTable) table: MatTable<any>;
  displayedColumns: string[] = ['serviceName', 'JM', 'quantity', 'netPrice', 'netWorth', 'vatRate', 'vatAmount', 'grossValue'];
  dataSource: Service[] = new Array();
  sumGrossValue = 0.00;
  sumNetValue = 0.00;

  constructor() { }

  ngOnInit(): void {
    this.dataSource.push(EMPTY_ROW);
  }

  addNewServicePosition() {
    this.dataSource.push({ serviceName: '', JM: 'szt.', quantity: 1, netPrice: 0.00,
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
    this.dataSource.forEach(function(record) {
      sumGross += record.grossValue;
      sumNet = record.netWorth;
    });
    this.sumGrossValue = sumGross;
    this.sumNetValue = sumNet;
  }
}

const EMPTY_ROW: Service = { serviceName: '', JM: 'szt.', quantity: 1, netPrice: 0.00,
netWorth: 0.00, vatRate: '23%', vatAmount: 0, grossValue: 0.00 };

export interface Service {
  serviceName: string;
  JM: string;
  quantity: number;
  netPrice: number;
  netWorth: number;
  vatRate: string;
  vatAmount: number;
  grossValue: number;
}


