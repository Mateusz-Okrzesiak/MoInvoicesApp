
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
                 }
  }

  export interface Contractor {
    name: string;
    nip: string;
    street: string;
    city: string;
    postalCode: string;
  }

  export interface InvoiceRowService {
    serviceName: string;
    JM: string;
    quantity: number;
    netPrice: number;
    netWorth: number;
    vatRate: string;
    vatAmount: number;
    grossValue: number;
  }


