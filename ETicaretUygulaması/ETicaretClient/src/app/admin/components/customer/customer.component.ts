import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from '../../../base/base.component';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.scss'
})
export class CustomerComponent extends BaseComponent implements OnInit{
constructor (spinner : NgxSpinnerService){
  super(spinner);
}
  ngOnInit(): void { 
    this.showSpinner(SpinnerType.BallAtom)
  }
}
