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

	setProperties(address1 : string,address2 : string,city : string,id : number,isDeleted : boolean,name : string,province : string,tenantId : number,website : string,zip : string) : void
	{
		this.address1 = address1;
this.address2 = address2;
this.city = city;
this.id = id;
this.isDeleted = isDeleted;
this.name = name;
this.province = province;
this.tenantId = tenantId;
this.website = website;
this.zip = zip;

	}
};

/*<Codenesium>
    <Hash>2b4648907753d5bff8db97c45f5e429a</Hash>
</Codenesium>*/