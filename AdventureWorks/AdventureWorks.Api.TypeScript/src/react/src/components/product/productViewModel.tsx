import moment from 'moment';
import ProductModelViewModel from '../productModel/productModelViewModel';
import ProductSubcategoryViewModel from '../productSubcategory/productSubcategoryViewModel';
import UnitMeasureViewModel from '../unitMeasure/unitMeasureViewModel';

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
  productModelIDEntity: string;
  productModelIDNavigation?: ProductModelViewModel;
  productNumber: string;
  productSubcategoryID: any;
  productSubcategoryIDEntity: string;
  productSubcategoryIDNavigation?: ProductSubcategoryViewModel;
  reorderPoint: number;
  rowguid: any;
  safetyStockLevel: number;
  sellEndDate: any;
  sellStartDate: any;
  size: string;
  sizeUnitMeasureCode: string;
  sizeUnitMeasureCodeEntity: string;
  sizeUnitMeasureCodeNavigation?: UnitMeasureViewModel;
  standardCost: number;
  style: string;
  weight: any;
  weightUnitMeasureCode: string;
  weightUnitMeasureCodeEntity: string;
  weightUnitMeasureCodeNavigation?: UnitMeasureViewModel;

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
    this.productModelIDEntity = '';
    this.productModelIDNavigation = new ProductModelViewModel();
    this.productNumber = '';
    this.productSubcategoryID = undefined;
    this.productSubcategoryIDEntity = '';
    this.productSubcategoryIDNavigation = new ProductSubcategoryViewModel();
    this.reorderPoint = 0;
    this.rowguid = undefined;
    this.safetyStockLevel = 0;
    this.sellEndDate = undefined;
    this.sellStartDate = undefined;
    this.size = '';
    this.sizeUnitMeasureCode = '';
    this.sizeUnitMeasureCodeEntity = '';
    this.sizeUnitMeasureCodeNavigation = new UnitMeasureViewModel();
    this.standardCost = 0;
    this.style = '';
    this.weight = undefined;
    this.weightUnitMeasureCode = '';
    this.weightUnitMeasureCodeEntity = '';
    this.weightUnitMeasureCodeNavigation = new UnitMeasureViewModel();
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
    this.color = moment(color, 'YYYY-MM-DD');
    this.daysToManufacture = moment(daysToManufacture, 'YYYY-MM-DD');
    this.discontinuedDate = moment(discontinuedDate, 'YYYY-MM-DD');
    this.finishedGoodsFlag = moment(finishedGoodsFlag, 'YYYY-MM-DD');
    this.listPrice = moment(listPrice, 'YYYY-MM-DD');
    this.makeFlag = moment(makeFlag, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = moment(name, 'YYYY-MM-DD');
    this.productID = moment(productID, 'YYYY-MM-DD');
    this.productLine = moment(productLine, 'YYYY-MM-DD');
    this.productModelID = moment(productModelID, 'YYYY-MM-DD');
    this.productNumber = moment(productNumber, 'YYYY-MM-DD');
    this.productSubcategoryID = moment(productSubcategoryID, 'YYYY-MM-DD');
    this.reorderPoint = moment(reorderPoint, 'YYYY-MM-DD');
    this.rowguid = moment(rowguid, 'YYYY-MM-DD');
    this.safetyStockLevel = moment(safetyStockLevel, 'YYYY-MM-DD');
    this.sellEndDate = moment(sellEndDate, 'YYYY-MM-DD');
    this.sellStartDate = moment(sellStartDate, 'YYYY-MM-DD');
    this.size = moment(size, 'YYYY-MM-DD');
    this.sizeUnitMeasureCode = moment(sizeUnitMeasureCode, 'YYYY-MM-DD');
    this.standardCost = moment(standardCost, 'YYYY-MM-DD');
    this.style = moment(style, 'YYYY-MM-DD');
    this.weight = moment(weight, 'YYYY-MM-DD');
    this.weightUnitMeasureCode = moment(weightUnitMeasureCode, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>f7d111a5cea6d0b03437fb8027b283b1</Hash>
</Codenesium>*/