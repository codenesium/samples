import moment from 'moment';
import PetViewModel from '../pet/petViewModel';

export default class SaleViewModel {
  amount: number;
  cutomerId: number;
  id: number;
  note: string;
  petId: number;
  petIdEntity: string;
  petIdNavigation?: PetViewModel;
  saleDate: any;
  salesPersonId: number;

  constructor() {
    this.amount = 0;
    this.cutomerId = 0;
    this.id = 0;
    this.note = '';
    this.petId = 0;
    this.petIdEntity = '';
    this.petIdNavigation = new PetViewModel();
    this.saleDate = undefined;
    this.salesPersonId = 0;
  }

  setProperties(
    amount: number,
    cutomerId: number,
    id: number,
    note: string,
    petId: number,
    saleDate: any,
    salesPersonId: number
  ): void {
    this.amount = amount;
    this.cutomerId = cutomerId;
    this.id = id;
    this.note = note;
    this.petId = petId;
    this.saleDate = moment(saleDate, 'YYYY-MM-DD');
    this.salesPersonId = salesPersonId;
  }

  toDisplay(): string {
    return String(this.amount);
  }
}


/*<Codenesium>
    <Hash>0ae466fd0c22e2e1c5578a1d5d2f7ed7</Hash>
</Codenesium>*/