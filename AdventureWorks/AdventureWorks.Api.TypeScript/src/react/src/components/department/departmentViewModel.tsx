export default class DepartmentViewModel {
    departmentID:number;
groupName:string;
modifiedDate:any;
name:string;

    constructor() {
		this.departmentID = 0;
this.groupName = '';
this.modifiedDate = undefined;
this.name = '';

    }

	setProperties(departmentID : number,groupName : string,modifiedDate : any,name : string) : void
	{
		this.departmentID = departmentID;
this.groupName = groupName;
this.modifiedDate = modifiedDate;
this.name = name;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>bef1f9a235d8e6c6c2135f2288da0e22</Hash>
</Codenesium>*/