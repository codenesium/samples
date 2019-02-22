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
    this.amount = moment(amount, 'YYYY-MM-DD');
    this.cutomerId = moment(cutomerId, 'YYYY-MM-DD');
    this.id = moment(id, 'YYYY-MM-DD');
    this.note = moment(note, 'YYYY-MM-DD');
    this.petId = moment(petId, 'YYYY-MM-DD');
    this.saleDate = moment(saleDate, 'YYYY-MM-DD');
    this.salesPersonId = moment(salesPersonId, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>e3c36d1cb0603857b8ffdeef1503b88a</Hash>
</Codenesium>*/