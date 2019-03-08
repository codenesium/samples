import moment from 'moment';
import BreedViewModel from '../breed/breedViewModel';
import PenViewModel from '../pen/penViewModel';

export default class PetViewModel {
  acquiredDate: any;
  breedId: number;
  breedIdEntity: string;
  breedIdNavigation?: BreedViewModel;
  description: string;
  penId: number;
  penIdEntity: string;
  penIdNavigation?: PenViewModel;
  price: number;

  constructor() {
    this.acquiredDate = undefined;
    this.breedId = 0;
    this.breedIdEntity = '';
    this.breedIdNavigation = new BreedViewModel();
    this.description = '';
    this.penId = 0;
    this.penIdEntity = '';
    this.penIdNavigation = new PenViewModel();
    this.price = 0;
  }

  setProperties(
    acquiredDate: any,
    breedId: number,
    description: string,
    penId: number,
    price: number
  ): void {
    this.acquiredDate = moment(acquiredDate, 'YYYY-MM-DD');
    this.breedId = breedId;
    this.description = description;
    this.penId = penId;
    this.price = price;
  }

  toDisplay(): string {
    return String(this.description);
  }
}


/*<Codenesium>
    <Hash>7107936f62370315547ffd5089689a2b</Hash>
</Codenesium>*/