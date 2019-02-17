export default class ProductViewModel {
  color: string;
  daysToManufacture: number;
  discontinuedDate: any;
  finishedGoodsFlag: boolean;
  listPrice: number;
  makeFlag: boolean;
  modifiedDate: any;
  name: string;
  productID: number;
  productLine: string;
  productModelID: any;
  productNumber: string;
  productSubcategoryID: any;
  reorderPoint: number;
  rowguid: any;
  safetyStockLevel: number;
  sellEndDate: any;
  sellStartDate: any;
  size: string;
  sizeUnitMeasureCode: string;
  standardCost: number;
  style: string;
  weight: any;
  weightUnitMeasureCode: string;

  constructor() {
    this.color = '';
    this.daysToManufacture = 0;
    this.discontinuedDate = undefined;
    this.finishedGoodsFlag = false;
    this.listPrice = 0;
    this.makeFlag = false;
    this.modifiedDate = undefined;
    this.name = '';
    this.productID = 0;
    this.productLine = '';
    this.productModelID = undefined;
    this.productNumber = '';
    this.productSubcategoryID = undefined;
    this.reorderPoint = 0;
    this.rowguid = undefined;
    this.safetyStockLevel = 0;
    this.sellEndDate = undefined;
    this.sellStartDate = undefined;
    this.size = '';
    this.sizeUnitMeasureCode = '';
    this.standardCost = 0;
    this.style = '';
    this.weight = undefined;
    this.weightUnitMeasureCode = '';
  }

  setProperties(
    color: string,
    daysToManufacture: number,
    discontinuedDate: any,
    finishedGoodsFlag: boolean,
    listPrice: number,
    makeFlag: boolean,
    modifiedDate: any,
    name: string,
    productID: number,
    productLine: string,
    productModelID: any,
    productNumber: string,
    productSubcategoryID: any,
    reorderPoint: number,
    rowguid: any,
    safetyStockLevel: number,
    sellEndDate: any,
    sellStartDate: any,
    size: string,
    sizeUnitMeasureCode: string,
    standardCost: number,
    style: string,
    weight: any,
    weightUnitMeasureCode: string
  ): void {
    this.color = color;
    this.daysToManufacture = daysToManufacture;
    this.discontinuedDate = discontinuedDate;
    this.finishedGoodsFlag = finishedGoodsFlag;
    this.listPrice = listPrice;
    this.makeFlag = makeFlag;
    this.modifiedDate = modifiedDate;
    this.name = name;
    this.productID = productID;
    this.productLine = productLine;
    this.productModelID = productModelID;
    this.productNumber = productNumber;
    this.productSubcategoryID = productSubcategoryID;
    this.reorderPoint = reorderPoint;
    this.rowguid = rowguid;
    this.safetyStockLevel = safetyStockLevel;
    this.sellEndDate = sellEndDate;
    this.sellStartDate = sellStartDate;
    this.size = size;
    this.sizeUnitMeasureCode = sizeUnitMeasureCode;
    this.standardCost = standardCost;
    this.style = style;
    this.weight = weight;
    this.weightUnitMeasureCode = weightUnitMeasureCode;
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>707801320bdadcc46cddd011891ae1c4</Hash>
</Codenesium>*/