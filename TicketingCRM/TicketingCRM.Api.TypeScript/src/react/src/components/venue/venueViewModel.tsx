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
    this.adminIdNavigation = new AdminViewModel();
    this.email = '';
    this.facebook = '';
    this.id = 0;
    this.name = '';
    this.phone = '';
    this.provinceId = 0;
    this.provinceIdEntity = '';
    this.provinceIdNavigation = new ProvinceViewModel();
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
    this.address1 = moment(address1, 'YYYY-MM-DD');
    this.address2 = moment(address2, 'YYYY-MM-DD');
    this.adminId = moment(adminId, 'YYYY-MM-DD');
    this.email = moment(email, 'YYYY-MM-DD');
    this.facebook = moment(facebook, 'YYYY-MM-DD');
    this.id = moment(id, 'YYYY-MM-DD');
    this.name = moment(name, 'YYYY-MM-DD');
    this.phone = moment(phone, 'YYYY-MM-DD');
    this.provinceId = moment(provinceId, 'YYYY-MM-DD');
    this.website = moment(website, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>e98b68c052919e1085f70c02718e6e70</Hash>
</Codenesium>*/