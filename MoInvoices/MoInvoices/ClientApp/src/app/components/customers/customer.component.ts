import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/models/Customer.model';
import { FormGroup, FormBuilder, NgForm } from '@angular/forms';
import { CustomerService } from 'src/app/services/customer.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-customers',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  customer: Customer = null;
  userForm: FormGroup;
  editMode: Boolean = false;

  constructor(private customerService: CustomerService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.initForm();
  }

  initForm() {
    const id = +this.route.snapshot.paramMap.get('customerID');
    this.editMode = (this.route.snapshot.url[1].path == "edit");

    if (this.editMode) {
      this.customerService.getCustomer(id).subscribe(c => {
        this.customer = c;
      });
    } else {
      this.customer = new Customer('', '', '', '', '', 1);
    }
  }

  addCustomer(form: NgForm) {
    this.customerService.createCustomer(this.customer).subscribe(() => {
      form.resetForm();
    });
  }

  update() {
    this.customerService.UpdateCustomer(this.customer);
  }
}
