import { Component, OnInit, ViewChild } from '@angular/core';
import { StringifyOptions } from 'querystring';
import { InvoiceService } from 'src/app/services/invoice.service';
import { InvoiceList } from 'src/app/interfaces/InvoiceList';
import { MatTable } from '@angular/material';

@Component({
  selector: 'app-invoices-list',
  templateUrl: './invoices-list.component.html',
  styleUrls: ['./invoices-list.component.scss']
})
export class InvoicesListComponent implements OnInit {

  @ViewChild(MatTable) invoiceTable: MatTable<any>;
  displayedColumns: string[] = ['id', 'documentType', 'invoiceNumber', 'purchaserName', 'issueDate', 'grossValue'];
  invoiceList: InvoiceList[];

  constructor(private invoiceService: InvoiceService) { }

  ngOnInit(): void {
    this.invoiceService.getAllUserInvoices().subscribe(response => {
      this.invoiceList = response;
    });
  }
  remove(id: number) {
    this.invoiceService.deleteInvoice(id).subscribe(() => {
      this.invoiceList = this.invoiceList.filter(i => i.invoiceID !== id);
      this.invoiceTable.renderRows();
    });
  }
}


