import moment from 'moment';

export default class BillOfMaterialViewModel {
  billOfMaterialsID: number;
  bOMLevel: number;
  componentID: number;
  endDate: any;
  modifiedDate: any;
  perAssemblyQty: number;
  productAssemblyID: any;
  startDate: any;
  unitMeasureCode: string;

  constructor() {
    this.billOfMaterialsID = 0;
    this.bOMLevel = 0;
    this.componentID = 0;
    this.endDate = undefined;
    this.modifiedDate = undefined;
    this.perAssemblyQty = 0;
    this.productAssemblyID = undefined;
    this.startDate = undefined;
    this.unitMeasureCode = '';
  }

  setProperties(
    billOfMaterialsID: number,
    bOMLevel: number,
    componentID: number,
    endDate: any,
    modifiedDate: any,
    perAssemblyQty: number,
    productAssemblyID: any,
    startDate: any,
    unitMeasureCode: string
  ): void {
    this.billOfMaterialsID = moment(billOfMaterialsID, 'YYYY-MM-DD');
    this.bOMLevel = moment(bOMLevel, 'YYYY-MM-DD');
    this.componentID = moment(componentID, 'YYYY-MM-DD');
    this.endDate = moment(endDate, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.perAssemblyQty = moment(perAssemblyQty, 'YYYY-MM-DD');
    this.productAssemblyID = moment(productAssemblyID, 'YYYY-MM-DD');
    this.startDate = moment(startDate, 'YYYY-MM-DD');
    this.unitMeasureCode = moment(unitMeasureCode, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>a7d31da23df3f4af706f98ee26c37a88</Hash>
</Codenesium>*/