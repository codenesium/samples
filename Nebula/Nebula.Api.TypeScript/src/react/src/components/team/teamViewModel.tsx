import moment from 'moment'
import OrganizationViewModel from '../organization/organizationViewModel'
	

export default class TeamViewModel {
    id:number;
name:string;
organizationId:number;
organizationIdEntity : string;
organizationIdNavigation? : OrganizationViewModel;

    constructor() {
		this.id = 0;
this.name = '';
this.organizationId = 0;
this.organizationIdEntity = '';
this.organizationIdNavigation = new OrganizationViewModel();

    }

	setProperties(id : number,name : string,organizationId : number) : void
	{
		this.id = id;
this.name = name;
this.organizationId = organizationId;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>5ab9376a54d018c6caa82724eec7d3d0</Hash>
</Codenesium>*/