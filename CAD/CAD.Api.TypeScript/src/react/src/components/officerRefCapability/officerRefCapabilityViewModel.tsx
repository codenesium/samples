import moment from 'moment'
import OfficerCapabilityViewModel from '../officerCapability/officerCapabilityViewModel'
	import OfficerViewModel from '../officer/officerViewModel'
	

export default class OfficerRefCapabilityViewModel {
    capabilityId:number;
capabilityIdEntity : string;
capabilityIdNavigation? : OfficerCapabilityViewModel;
id:number;
officerId:number;
officerIdEntity : string;
officerIdNavigation? : OfficerViewModel;

    constructor() {
		this.capabilityId = 0;
this.capabilityIdEntity = '';
this.capabilityIdNavigation = new OfficerCapabilityViewModel();
this.id = 0;
this.officerId = 0;
this.officerIdEntity = '';
this.officerIdNavigation = new OfficerViewModel();

    }

	setProperties(capabilityId : number,id : number,officerId : number) : void
	{
		this.capabilityId = capabilityId;
this.id = id;
this.officerId = officerId;

	}

	toDisplay() : string
	{
		return String(this.capabilityId);
	}
};

/*<Codenesium>
    <Hash>5f2b284253883033023835b81f75594c</Hash>
</Codenesium>*/