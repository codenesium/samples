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
    this.paymentTypeIdNavigation = new PaymentTypeViewModel();
    this.petId = 0;
    this.petIdEntity = '';
    this.petIdNavigation = new PetViewModel();
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
    <Hash>9b45cc7a861a8d75fddae87a11b3ade9</Hash>
</Codenesium>*/