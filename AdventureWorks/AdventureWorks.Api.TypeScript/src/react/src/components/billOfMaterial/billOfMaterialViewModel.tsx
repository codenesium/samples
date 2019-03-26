import moment from 'moment';
import ProductViewModel from '../product/productViewModel';
import UnitMeasureViewModel from '../unitMeasure/unitMeasureViewModel';

export default class BillOfMaterialViewModel {
  billOfMaterialsID: number;
  bOMLevel: number;
  componentID: number;
  componentIDEntity: string;
  componentIDNavigation?: ProductViewModel;
  endDate: any;
  modifiedDate: any;
  perAssemblyQty: number;
  productAssemblyID: number;
  productAssemblyIDEntity: string;
  productAssemblyIDNavigation?: ProductViewModel;
  startDate: any;
  unitMeasureCode: string;
  unitMeasureCodeEntity: string;
  unitMeasureCodeNavigation?: UnitMeasureViewModel;

  constructor() {
    this.billOfMaterialsID = 0;
    this.bOMLevel = 0;
    this.componentID = 0;
    this.componentIDEntity = '';
    this.componentIDNavigation = undefined;
    this.endDate = undefined;
    this.modifiedDate = undefined;
    this.perAssemblyQty = 0;
    this.productAssemblyID = 0;
    this.productAssemblyIDEntity = '';
    this.productAssemblyIDNavigation = undefined;
    this.startDate = undefined;
    this.unitMeasureCode = '';
    this.unitMeasureCodeEntity = '';
    this.unitMeasureCodeNavigation = undefined;
  }

  setProperties(
    billOfMaterialsID: number,
    bOMLevel: number,
    componentID: number,
    endDate: any,
    modifiedDate: any,
    perAssemblyQty: number,
    productAssemblyID: number,
    startDate: any,
    unitMeasureCode: string
  ): void {
    this.billOfMaterialsID = billOfMaterialsID;
    this.bOMLevel = bOMLevel;
    this.componentID = componentID;
    this.endDate = moment(endDate, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.perAssemblyQty = perAssemblyQty;
    this.productAssemblyID = productAssemblyID;
    this.startDate = moment(startDate, 'YYYY-MM-DD');
    this.unitMeasureCode = unitMeasureCode;
  }

  toDisplay(): string {
    return String(this.billOfMaterialsID);
  }
}


/*<Codenesium>
    <Hash>3edd952a77d93e6ea8f5dd3d6a6f9d94</Hash>
</Codenesium>*/