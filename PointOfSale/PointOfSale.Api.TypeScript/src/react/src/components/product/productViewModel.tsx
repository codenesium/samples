import moment from 'moment';

export default class ProductViewModel {
  active: boolean;
  description: string;
  id: number;
  name: string;
  price: number;
  quantity: number;

  constructor() {
    this.active = false;
    this.description = '';
    this.id = 0;
    this.name = '';
    this.price = 0;
    this.quantity = 0;
  }

  setProperties(
    active: boolean,
    description: string,
    id: number,
    name: string,
    price: number,
    quantity: number
  ): void {
    this.active = active;
    this.description = description;
    this.id = id;
    this.name = name;
    this.price = price;
    this.quantity = quantity;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>d57ef4b4e2d186395f1e828ed16b9f90</Hash>
</Codenesium>*/