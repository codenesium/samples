import moment from 'moment';

export default class SpecialOfferViewModel {
  category: string;
  description: string;
  discountPct: number;
  endDate: any;
  maxQty: any;
  minQty: number;
  modifiedDate: any;
  rowguid: any;
  specialOfferID: number;
  startDate: any;

  constructor() {
    this.category = '';
    this.description = '';
    this.discountPct = 0;
    this.endDate = undefined;
    this.maxQty = undefined;
    this.minQty = 0;
    this.modifiedDate = undefined;
    this.rowguid = undefined;
    this.specialOfferID = 0;
    this.startDate = undefined;
  }

  setProperties(
    category: string,
    description: string,
    discountPct: number,
    endDate: any,
    maxQty: any,
    minQty: number,
    modifiedDate: any,
    rowguid: any,
    specialOfferID: number,
    startDate: any
  ): void {
    this.category = moment(category, 'YYYY-MM-DD');
    this.description = moment(description, 'YYYY-MM-DD');
    this.discountPct = moment(discountPct, 'YYYY-MM-DD');
    this.endDate = moment(endDate, 'YYYY-MM-DD');
    this.maxQty = moment(maxQty, 'YYYY-MM-DD');
    this.minQty = moment(minQty, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.rowguid = moment(rowguid, 'YYYY-MM-DD');
    this.specialOfferID = moment(specialOfferID, 'YYYY-MM-DD');
    this.startDate = moment(startDate, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>b12b888f7943d6cc43828bfa2aadf94d</Hash>
</Codenesium>*/