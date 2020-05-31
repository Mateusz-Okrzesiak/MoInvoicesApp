import { Contractor } from "../interfaces/contractor";
import { InvoiceRowService } from "../interfaces/InvoiceRowService";
import { PaymentType } from "../interfaces/paymentType";

  export class Invoice {
    invoiceID: number;
    documentTypeID: number;
    invoiceNumber: string;
    sellDate: Date;
    issueDate: Date;
    cityOfIssue: string;
    services: InvoiceRowService[];
    purchaser: Contractor;
    vendor: Contractor;
    isPayed: Boolean;
    sumGrossValue: number;
    sumNetValue: number;
    userID: number;
    paymentDate: Date;
    accountNR: string;
    paymentStatusID: number;
    paymentTypeID: number;

    constructor(invoiceID: number, documentTypeID: number, invoiceNumber: string,
                sellData: Date, issueDate: Date, cityOfIssue: string, services: InvoiceRowService [],
                 purchaser: Contractor, vendor: Contractor, isPayed: Boolean, sumGrossValue: number,
                 sumNetValue: number, userID: number, accountNR: string, paymentStatusID: number) {
                   this.invoiceID = invoiceID;
                   this.documentTypeID = documentTypeID;
                   this.invoiceNumber = invoiceNumber;
                   this.sellDate = sellData;
                   this.issueDate = issueDate;
                   this.cityOfIssue = cityOfIssue;
                   this.services = services;
                   this.purchaser = purchaser;
                   this.vendor = vendor;
                   this.isPayed = isPayed;
                   this.sumGrossValue = sumGrossValue;
                   this.sumNetValue = sumNetValue;
                   this.userID = userID;
                   this.accountNR = accountNR;
                   this.paymentStatusID = paymentStatusID;
                 }

  }



