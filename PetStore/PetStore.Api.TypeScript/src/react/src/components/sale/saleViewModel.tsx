import moment from 'moment';
import PaymentTypeViewModel from '../paymentType/paymentTypeViewModel';
import PetViewModel from '../pet/petViewModel';

export default class SaleViewModel {
  amount: number;
  firstName: string;
  id: number;
  lastName: string;
  paymentTypeId: number;
  paymentTypeIdEntity: string;
  paymentTypeIdNavigation?: PaymentTypeViewModel;
  petId: number;
  petIdEntity: string;
  petIdNavigation?: PetViewModel;
  phone: string;

  constructor() {
    this.amount = 0;
    this.firstName = '';
    this.id = 0;
    this.lastName = '';
    this.paymentTypeId = 0;
    this.paymentTypeIdEntity = '';
    this.paymentTypeIdNavigation = undefined;
    this.petId = 0;
    this.petIdEntity = '';
    this.petIdNavigation = undefined;
    this.phone = '';
  }

  setProperties(
    amount: number,
    firstName: string,
    id: number,
    lastName: string,
    paymentTypeId: number,
    petId: number,
    phone: string
  ): void {
    this.amount = amount;
    this.firstName = firstName;
    this.id = id;
    this.lastName = lastName;
    this.paymentTypeId = paymentTypeId;
    this.petId = petId;
    this.phone = phone;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>70f8d8e3f122d0e7fe10f883dac8e8f0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/