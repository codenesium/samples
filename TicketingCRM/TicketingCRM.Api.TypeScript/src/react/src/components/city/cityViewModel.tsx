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
    this.provinceIdNavigation = new ProvinceViewModel();
  }

  setProperties(id: number, name: string, provinceId: number): void {
    this.id = moment(id, 'YYYY-MM-DD');
    this.name = name;
    this.provinceId = provinceId;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>9b29b4e0a9d27dfab62e8b7fe6a8b44d</Hash>
</Codenesium>*/