import moment from 'moment'


export default class HandlerViewModel {
    countryId:number;
email:string;
firstName:string;
id:number;
lastName:string;
phone:string;

    constructor() {
		this.countryId = 0;
this.email = '';
this.firstName = '';
this.id = 0;
this.lastName = '';
this.phone = '';

    }

	setProperties(countryId : number,email : string,firstName : string,id : number,lastName : string,phone : string) : void
	{
		this.countryId = moment(countryId,'YYYY-MM-DD');
this.email = moment(email,'YYYY-MM-DD');
this.firstName = moment(firstName,'YYYY-MM-DD');
this.id = moment(id,'YYYY-MM-DD');
this.lastName = moment(lastName,'YYYY-MM-DD');
this.phone = moment(phone,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>a234b48d151eff31dfd326895095874c</Hash>
</Codenesium>*/