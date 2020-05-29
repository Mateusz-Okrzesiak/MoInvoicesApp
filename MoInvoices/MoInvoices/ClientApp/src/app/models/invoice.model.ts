import { Contractor } from "../interfaces/Contractor";
import { InvoiceRowService } from "../interfaces/InvoiceRowService";

  export class Invoice {
    invoiceID: number;
    documentType: string;
    invoiceNumber: string;
    sellData: Date;
    issueDate: Date;
    cityOfIssue: string;
    service: InvoiceRowService[];
    purchaser: Contractor;
    vendor: Contractor;
    isPayed: Boolean;
    sumGrossValue: number;
    sumNetValue: number;
    userID: number;

    constructor(invoiceID: number, documentType: string, invoiceNumber: string,
                sellData: Date, issueDate: Date, cityOfIssue: string, service: InvoiceRowService [],
                 purchaser: Contractor, vendor: Contractor, isPayed: Boolean, sumGrossValue: number, sumNetValue: number) {
                   this.invoiceID = invoiceID;
                   this.documentType = documentType;
                   this.invoiceNumber = invoiceNumber;
                   this.sellData = sellData;
                   this.issueDate = issueDate;
                   this.cityOfIssue = cityOfIssue;
                   this.service = service;
                   this.purchaser = purchaser;
                   this.vendor = vendor;
                   this.isPayed = isPayed;
                   this.sumGrossValue = sumGrossValue;
                   this.sumNetValue = sumNetValue;
                   this.userID = this.userID;
                 }

                 
  }
  


