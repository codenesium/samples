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
    this.businessEntityIDNavigation = undefined;
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
    this.additionalContactInfo = additionalContactInfo;
    this.businessEntityID = businessEntityID;
    this.demographic = demographic;
    this.emailPromotion = emailPromotion;
    this.firstName = firstName;
    this.lastName = lastName;
    this.middleName = middleName;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.nameStyle = nameStyle;
    this.personType = personType;
    this.rowguid = rowguid;
    this.suffix = suffix;
    this.title = title;
  }

  toDisplay(): string {
    return String(this.rowguid);
  }
}


/*<Codenesium>
    <Hash>1d35ba2a45dccdabf9ba1b497df35e76</Hash>
</Codenesium>*/