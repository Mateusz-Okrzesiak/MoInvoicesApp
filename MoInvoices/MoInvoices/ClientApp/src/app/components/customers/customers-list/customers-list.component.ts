import { Component, OnInit, ViewChild } from '@angular/core';
import { CustomerList } from 'src/app/interfaces/customerList';
import { CustomerService } from 'src/app/services/customer.service';
import { MatTable } from '@angular/material';

@Component({
  selector: 'app-customers-list',
  templateUrl: './customers-list.component.html',
  styleUrls: ['./customers-list.component.scss']
})
export class CustomersListComponent implements OnInit {

  @ViewChild(MatTable) customerTable: MatTable<any>;
  displayedColumns: string[] = ['id', 'customerName', 'nip', 'city', 'street'];
  customerList: CustomerList[];


  constructor(private customerService: CustomerService) { }

  ngOnInit() {
    this.customerService.getAllUserCustomers().subscribe(ctr => {
      this.customerList = ctr;
    });
  }

  remove(id: number) {
      this.customerService.deleteCustomer(id).subscribe(() => {
        this.customerList = this.customerList.filter(c => c.customerID !== id);
        this.customerTable.renderRows();
      });
    }
}
