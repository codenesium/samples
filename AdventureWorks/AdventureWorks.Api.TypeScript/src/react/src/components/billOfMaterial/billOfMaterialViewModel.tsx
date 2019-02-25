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
  productAssemblyID: any;
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
    this.componentIDNavigation = new ProductViewModel();
    this.endDate = undefined;
    this.modifiedDate = undefined;
    this.perAssemblyQty = 0;
    this.productAssemblyID = undefined;
    this.productAssemblyIDEntity = '';
    this.productAssemblyIDNavigation = new ProductViewModel();
    this.startDate = undefined;
    this.unitMeasureCode = '';
    this.unitMeasureCodeEntity = '';
    this.unitMeasureCodeNavigation = new UnitMeasureViewModel();
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
    <Hash>b8b54c71b7d560d36476794f465f3a08</Hash>
</Codenesium>*/