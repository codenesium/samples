import moment from 'moment'


export default class StudioViewModel {
    address1:string;
address2:string;
city:string;
id:number;
name:string;
province:string;
website:string;
zip:string;

    constructor() {
		this.address1 = '';
this.address2 = '';
this.city = '';
this.id = 0;
this.name = '';
this.province = '';
this.website = '';
this.zip = '';

    }

	setProperties(address1 : string,address2 : string,city : string,id : number,name : string,province : string,website : string,zip : string) : void
	{
		this.address1 = moment(address1,'YYYY-MM-DD');
this.address2 = moment(address2,'YYYY-MM-DD');
this.city = moment(city,'YYYY-MM-DD');
this.id = moment(id,'YYYY-MM-DD');
this.name = moment(name,'YYYY-MM-DD');
this.province = moment(province,'YYYY-MM-DD');
this.website = moment(website,'YYYY-MM-DD');
this.zip = moment(zip,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>7252087fbfad6eb5e53d2236283cc8f1</Hash>
</Codenesium>*/