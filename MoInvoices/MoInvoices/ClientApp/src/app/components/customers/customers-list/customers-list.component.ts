import { Component, OnInit } from '@angular/core';
import { CustomerList } from 'src/app/interfaces/customerList';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customers-list',
  templateUrl: './customers-list.component.html',
  styleUrls: ['./customers-list.component.scss']
})
export class CustomersListComponent implements OnInit {

  displayedColumns: string[] = ['id', 'customerName', 'nip', 'city', 'street'];
  customerList: CustomerList[];


  constructor(private customerService: CustomerService) { }

  ngOnInit() {
    this.customerService.getAllUserCustomers().subscribe(ctr => {
      this.customerList = ctr;
    });

  }

}
