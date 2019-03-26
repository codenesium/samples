import moment from 'moment';

export default class SpecialOfferViewModel {
  category: string;
  description: string;
  discountPct: number;
  endDate: any;
  maxQty: number;
  minQty: number;
  modifiedDate: any;
  rowguid: any;
  specialOfferID: number;
  startDate: any;
  reservedType: string;

  constructor() {
    this.category = '';
    this.description = '';
    this.discountPct = 0;
    this.endDate = undefined;
    this.maxQty = 0;
    this.minQty = 0;
    this.modifiedDate = undefined;
    this.rowguid = undefined;
    this.specialOfferID = 0;
    this.startDate = undefined;
    this.reservedType = '';
  }

  setProperties(
    category: string,
    description: string,
    discountPct: number,
    endDate: any,
    maxQty: number,
    minQty: number,
    modifiedDate: any,
    rowguid: any,
    specialOfferID: number,
    startDate: any,
    reservedType: string
  ): void {
    this.category = category;
    this.description = description;
    this.discountPct = discountPct;
    this.endDate = moment(endDate, 'YYYY-MM-DD');
    this.maxQty = maxQty;
    this.minQty = minQty;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.rowguid = rowguid;
    this.specialOfferID = specialOfferID;
    this.startDate = moment(startDate, 'YYYY-MM-DD');
    this.reservedType = reservedType;
  }

  toDisplay(): string {
    return String(this.rowguid);
  }
}


/*<Codenesium>
    <Hash>ded9369dc228044362bfd65f8034ad7e</Hash>
</Codenesium>*/