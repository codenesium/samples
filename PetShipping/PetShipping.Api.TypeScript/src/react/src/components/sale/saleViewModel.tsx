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
    this.petIdNavigation = undefined;
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
    this.saleDate = saleDate;
    this.salesPersonId = salesPersonId;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>2a744cd06ab6e6a4a7f2c890770db18b</Hash>
</Codenesium>*/