import moment from 'moment'


export default class ContactTypeViewModel {
    contactTypeID:number;
modifiedDate:any;
name:string;

    constructor() {
		this.contactTypeID = 0;
this.modifiedDate = undefined;
this.name = '';

    }

	setProperties(contactTypeID : number,modifiedDate : any,name : string) : void
	{
		this.contactTypeID = moment(contactTypeID,'YYYY-MM-DD');
this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.name = moment(name,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>81b95f1b24facacb3d140f349533966f</Hash>
</Codenesium>*/