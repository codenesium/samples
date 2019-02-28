import moment from 'moment'


export default class ProductDescriptionViewModel {
    description:string;
modifiedDate:any;
productDescriptionID:number;
rowguid:any;

    constructor() {
		this.description = '';
this.modifiedDate = undefined;
this.productDescriptionID = 0;
this.rowguid = undefined;

    }

	setProperties(description : string,modifiedDate : any,productDescriptionID : number,rowguid : any) : void
	{
		this.description = moment(description,'YYYY-MM-DD');
this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.productDescriptionID = moment(productDescriptionID,'YYYY-MM-DD');
this.rowguid = moment(rowguid,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>70577982bdbc1dfa2d0b62724801f225</Hash>
</Codenesium>*/