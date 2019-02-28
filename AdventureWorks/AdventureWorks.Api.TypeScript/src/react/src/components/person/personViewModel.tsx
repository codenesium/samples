import moment from 'moment';
import BusinessEntityViewModel from '../businessEntity/businessEntityViewModel';

export default class PersonViewModel {
  additionalContactInfo: string;
  businessEntityID: number;
  businessEntityIDEntity: string;
  businessEntityIDNavigation?: BusinessEntityViewModel;
  demographic: string;
  emailPromotion: number;
  firstName: string;
  lastName: string;
  middleName: string;
  modifiedDate: any;
  nameStyle: boolean;
  personType: string;
  rowguid: any;
  suffix: string;
  title: string;

  constructor() {
    this.additionalContactInfo = '';
    this.businessEntityID = 0;
    this.businessEntityIDEntity = '';
    this.businessEntityIDNavigation = new BusinessEntityViewModel();
    this.demographic = '';
    this.emailPromotion = 0;
    this.firstName = '';
    this.lastName = '';
    this.middleName = '';
    this.modifiedDate = undefined;
    this.nameStyle = false;
    this.personType = '';
    this.rowguid = undefined;
    this.suffix = '';
    this.title = '';
  }

  setProperties(
    additionalContactInfo: string,
    businessEntityID: number,
    demographic: string,
    emailPromotion: number,
    firstName: string,
    lastName: string,
    middleName: string,
    modifiedDate: any,
    nameStyle: boolean,
    personType: string,
    rowguid: any,
    suffix: string,
    title: string
  ): void {
    this.additionalContactInfo = moment(additionalContactInfo, 'YYYY-MM-DD');
    this.businessEntityID = moment(businessEntityID, 'YYYY-MM-DD');
    this.demographic = moment(demographic, 'YYYY-MM-DD');
    this.emailPromotion = moment(emailPromotion, 'YYYY-MM-DD');
    this.firstName = moment(firstName, 'YYYY-MM-DD');
    this.lastName = moment(lastName, 'YYYY-MM-DD');
    this.middleName = moment(middleName, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.nameStyle = moment(nameStyle, 'YYYY-MM-DD');
    this.personType = moment(personType, 'YYYY-MM-DD');
    this.rowguid = moment(rowguid, 'YYYY-MM-DD');
    this.suffix = moment(suffix, 'YYYY-MM-DD');
    this.title = moment(title, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>156b32b2b862feba9e68857ed3120b7f</Hash>
</Codenesium>*/