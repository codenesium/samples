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
    this.category = category;
    this.description = description;
    this.discountPct = discountPct;
    this.endDate = endDate;
    this.maxQty = maxQty;
    this.minQty = minQty;
    this.modifiedDate = modifiedDate;
    this.rowguid = rowguid;
    this.specialOfferID = specialOfferID;
    this.startDate = startDate;
  }
}


/*<Codenesium>
    <Hash>d33671cab802a1221fd45478b4daf310</Hash>
</Codenesium>*/