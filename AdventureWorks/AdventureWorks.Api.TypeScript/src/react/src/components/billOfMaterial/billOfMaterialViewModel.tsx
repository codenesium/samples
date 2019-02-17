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
    this.billOfMaterialsID = billOfMaterialsID;
    this.bOMLevel = bOMLevel;
    this.componentID = componentID;
    this.endDate = endDate;
    this.modifiedDate = modifiedDate;
    this.perAssemblyQty = perAssemblyQty;
    this.productAssemblyID = productAssemblyID;
    this.startDate = startDate;
    this.unitMeasureCode = unitMeasureCode;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>7f176158d79c121ed4cffb5f5fc25e46</Hash>
</Codenesium>*/