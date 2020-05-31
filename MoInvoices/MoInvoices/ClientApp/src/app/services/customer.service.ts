import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../models/Customer.model';
import { CustomerList } from '../interfaces/customerList';

@Injectable()
export class CustomerService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  createCustomer(customer: Customer) {
    customer.userID = 1;
    this.httpClient.post<Customer>(this.baseUrl + 'customer', customer).subscribe();
  }

  getCustomer(customerID: number) {
    return this.httpClient.get<Customer>(this.baseUrl + `customer/${customerID}`);
  }

  deleteCustomer(customerID: number) {
    return this.httpClient.delete<Customer>(this.baseUrl + `customer/${customerID}`);
  }

  UpdateCustomer(customer: Customer) {
    customer.userID = 1;
    this.httpClient.put<Customer>(this.baseUrl + 'customer', customer).subscribe();
  }

  getAllUserCustomers() {
    const userID = 1;
    return this.httpClient.get<CustomerList[]>(this.baseUrl + `customer/AllUserCustomers/${userID}`);
  }

}
