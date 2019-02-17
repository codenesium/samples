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
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>92519b4ec30b97b6dfce02f99347dbbf</Hash>
</Codenesium>*/