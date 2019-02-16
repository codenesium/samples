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
    return String();
  }
}


/*<Codenesium>
    <Hash>efc72b45c0e6a28133517ac25f6097cd</Hash>
</Codenesium>*/