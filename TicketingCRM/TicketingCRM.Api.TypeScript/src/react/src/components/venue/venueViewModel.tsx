import moment from 'moment';
import AdminViewModel from '../admin/adminViewModel';
import ProvinceViewModel from '../province/provinceViewModel';

export default class VenueViewModel {
  address1: string;
  address2: string;
  adminId: number;
  adminIdEntity: string;
  adminIdNavigation?: AdminViewModel;
  email: string;
  facebook: string;
  id: number;
  name: string;
  phone: string;
  provinceId: number;
  provinceIdEntity: string;
  provinceIdNavigation?: ProvinceViewModel;
  website: string;

  constructor() {
    this.address1 = '';
    this.address2 = '';
    this.adminId = 0;
    this.adminIdEntity = '';
    this.adminIdNavigation = undefined;
    this.email = '';
    this.facebook = '';
    this.id = 0;
    this.name = '';
    this.phone = '';
    this.provinceId = 0;
    this.provinceIdEntity = '';
    this.provinceIdNavigation = undefined;
    this.website = '';
  }

  setProperties(
    address1: string,
    address2: string,
    adminId: number,
    email: string,
    facebook: string,
    id: number,
    name: string,
    phone: string,
    provinceId: number,
    website: string
  ): void {
    this.address1 = address1;
    this.address2 = address2;
    this.adminId = adminId;
    this.email = email;
    this.facebook = facebook;
    this.id = id;
    this.name = name;
    this.phone = phone;
    this.provinceId = provinceId;
    this.website = website;
  }

  toDisplay(): string {
    return String(this.address1);
  }
}


/*<Codenesium>
    <Hash>a66f311360fa0c5713a53dc14e0f7097</Hash>
</Codenesium>*/