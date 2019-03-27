import moment from 'moment';
import ProvinceViewModel from '../province/provinceViewModel';

export default class CityViewModel {
  id: number;
  name: string;
  provinceId: number;
  provinceIdEntity: string;
  provinceIdNavigation?: ProvinceViewModel;

  constructor() {
    this.id = 0;
    this.name = '';
    this.provinceId = 0;
    this.provinceIdEntity = '';
    this.provinceIdNavigation = undefined;
  }

  setProperties(id: number, name: string, provinceId: number): void {
    this.id = id;
    this.name = name;
    this.provinceId = provinceId;
  }

  toDisplay(): string {
    return String(this.id);
  }
}


/*<Codenesium>
    <Hash>ecc7bb96e066257dc7eb63737d71243b</Hash>
</Codenesium>*/