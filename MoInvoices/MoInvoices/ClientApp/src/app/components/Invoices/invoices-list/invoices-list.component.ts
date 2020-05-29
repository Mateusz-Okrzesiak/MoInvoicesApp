import { Component, OnInit } from '@angular/core';
import { StringifyOptions } from 'querystring';
import { InvoiceService } from 'src/app/services/invoice.service';
import { InvoiceList } from 'src/app/interfaces/InvoiceList';

@Component({
  selector: 'app-invoices-list',
  templateUrl: './invoices-list.component.html',
  styleUrls: ['./invoices-list.component.scss']
})
export class InvoicesListComponent implements OnInit {

  displayedColumns: string[] = ['id', 'documentType', 'invoiceNumber', 'purchaserName', 'issueDate', 'grossValue'];
  invoiceList: InvoiceList[];


  constructor(private invoiceService: InvoiceService) { }

  ngOnInit(): void {
    this.invoiceService.GetAllUserInvoices().subscribe(response => {
      this.invoiceList = response;
    });
  }
}


