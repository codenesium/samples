import moment from 'moment';
import ProductModelViewModel from '../productModel/productModelViewModel';
import ProductSubcategoryViewModel from '../productSubcategory/productSubcategoryViewModel';
import UnitMeasureViewModel from '../unitMeasure/unitMeasureViewModel';

export default class ProductViewModel {
  reservedClass: string;
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
  productModelID: number;
  productModelIDEntity: string;
  productModelIDNavigation?: ProductModelViewModel;
  productNumber: string;
  productSubcategoryID: number;
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
  weight: number;
  weightUnitMeasureCode: string;
  weightUnitMeasureCodeEntity: string;
  weightUnitMeasureCodeNavigation?: UnitMeasureViewModel;

  constructor() {
    this.reservedClass = '';
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
    this.productModelID = 0;
    this.productModelIDEntity = '';
    this.productModelIDNavigation = undefined;
    this.productNumber = '';
    this.productSubcategoryID = 0;
    this.productSubcategoryIDEntity = '';
    this.productSubcategoryIDNavigation = undefined;
    this.reorderPoint = 0;
    this.rowguid = undefined;
    this.safetyStockLevel = 0;
    this.sellEndDate = undefined;
    this.sellStartDate = undefined;
    this.size = '';
    this.sizeUnitMeasureCode = '';
    this.sizeUnitMeasureCodeEntity = '';
    this.sizeUnitMeasureCodeNavigation = undefined;
    this.standardCost = 0;
    this.style = '';
    this.weight = 0;
    this.weightUnitMeasureCode = '';
    this.weightUnitMeasureCodeEntity = '';
    this.weightUnitMeasureCodeNavigation = undefined;
  }

  setProperties(
    reservedClass: string,
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
    productModelID: number,
    productNumber: string,
    productSubcategoryID: number,
    reorderPoint: number,
    rowguid: any,
    safetyStockLevel: number,
    sellEndDate: any,
    sellStartDate: any,
    size: string,
    sizeUnitMeasureCode: string,
    standardCost: number,
    style: string,
    weight: number,
    weightUnitMeasureCode: string
  ): void {
    this.reservedClass = reservedClass;
    this.color = color;
    this.daysToManufacture = daysToManufacture;
    this.discontinuedDate = moment(discontinuedDate, 'YYYY-MM-DD');
    this.finishedGoodsFlag = finishedGoodsFlag;
    this.listPrice = listPrice;
    this.makeFlag = makeFlag;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.name = name;
    this.productID = productID;
    this.productLine = productLine;
    this.productModelID = productModelID;
    this.productNumber = productNumber;
    this.productSubcategoryID = productSubcategoryID;
    this.reorderPoint = reorderPoint;
    this.rowguid = rowguid;
    this.safetyStockLevel = safetyStockLevel;
    this.sellEndDate = moment(sellEndDate, 'YYYY-MM-DD');
    this.sellStartDate = moment(sellStartDate, 'YYYY-MM-DD');
    this.size = size;
    this.sizeUnitMeasureCode = sizeUnitMeasureCode;
    this.standardCost = standardCost;
    this.style = style;
    this.weight = weight;
    this.weightUnitMeasureCode = weightUnitMeasureCode;
  }

  toDisplay(): string {
    return String(this.name);
  }
}


/*<Codenesium>
    <Hash>afa57326186cf53191109dfda80c4cc5</Hash>
</Codenesium>*/