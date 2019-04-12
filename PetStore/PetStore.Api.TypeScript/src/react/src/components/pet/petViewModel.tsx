import moment from 'moment';
import BreedViewModel from '../breed/breedViewModel';
import PenViewModel from '../pen/penViewModel';

export default class PetViewModel {
  acquiredDate: any;
  breedId: number;
  breedIdEntity: string;
  breedIdNavigation?: BreedViewModel;
  description: string;
  id: number;
  penId: number;
  penIdEntity: string;
  penIdNavigation?: PenViewModel;
  price: number;

  constructor() {
    this.acquiredDate = undefined;
    this.breedId = 0;
    this.breedIdEntity = '';
    this.breedIdNavigation = undefined;
    this.description = '';
    this.id = 0;
    this.penId = 0;
    this.penIdEntity = '';
    this.penIdNavigation = undefined;
    this.price = 0;
  }

  setProperties(
    acquiredDate: any,
    breedId: number,
    description: string,
    id: number,
    penId: number,
    price: number
  ): void {
    this.acquiredDate = moment(acquiredDate, 'YYYY-MM-DD');
    this.breedId = breedId;
    this.description = description;
    this.id = id;
    this.penId = penId;
    this.price = price;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>e684d363dfb4a69d8fa227da2e6f7df4</Hash>
</Codenesium>*/