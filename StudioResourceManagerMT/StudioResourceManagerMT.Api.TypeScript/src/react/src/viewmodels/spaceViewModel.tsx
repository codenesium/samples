export default class SpaceViewModel {
    description:string;
id:number;
name:string;

    constructor() {
		this.description = '';
this.id = 0;
this.name = '';

    }

	setProperties(description : string,id : number,isDeleted : boolean,name : string,tenantId : number) : void
	{
		this.description = description;
this.id = id;
this.isDeleted = isDeleted;
this.name = name;
this.tenantId = tenantId;

	}
};

/*<Codenesium>
    <Hash>abfa0affa685248801f2e404f6a77c8a</Hash>
</Codenesium>*/