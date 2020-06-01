import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/models/Customer.model';
import { FormGroup, FormBuilder, NgForm } from '@angular/forms';
import { CustomerService } from 'src/app/services/customer.service';
import { ActivatedRoute, Router } from '@angular/router';

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
              private activatedRoute: ActivatedRoute,
              private router: Router) { }

  ngOnInit() {
    this.initForm();
  }

  initForm() {
    const id = +this.activatedRoute.snapshot.paramMap.get('customerID');
    this.editMode = (this.activatedRoute.snapshot.url[1].path == "edit");

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
      this.router.navigateByUrl('/customer-list');
    });
  }

  update() {
    this.customerService.UpdateCustomer(this.customer);
  }
}
