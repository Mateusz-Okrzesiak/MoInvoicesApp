import { Component, OnInit } from '@angular/core';
import { Invoice } from 'src/app/models/invoice.model';
import { InvoiceService } from 'src/app/services/invoice.service';

@Component({
  selector: 'app-edit-invoice',
  templateUrl: './edit-invoice.component.html',
  styleUrls: ['./edit-invoice.component.scss']
})
export class EditInvoiceComponent implements OnInit {

  currentInvoice: Invoice;

  constructor(private invoiceService: InvoiceService, ) { }

  ngOnInit() {
   // this.currentInvoice = this.invoiceService
   // this.invoice.service.push(EMPTY_ROW);
   this.invoiceService.GetInvoice(11);
  }

}
