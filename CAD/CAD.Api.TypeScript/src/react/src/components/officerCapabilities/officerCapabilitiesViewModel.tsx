import moment from 'moment'
import OfficerCapabilityViewModel from '../officerCapability/officerCapabilityViewModel'
	import OfficerViewModel from '../officer/officerViewModel'
	

export default class OfficerCapabilitiesViewModel {
    capabilityId:number;
capabilityIdEntity : string;
capabilityIdNavigation? : OfficerCapabilityViewModel;
officerId:number;
officerIdEntity : string;
officerIdNavigation? : OfficerViewModel;

    constructor() {
		this.capabilityId = 0;
this.capabilityIdEntity = '';
this.capabilityIdNavigation = new OfficerCapabilityViewModel();
this.officerId = 0;
this.officerIdEntity = '';
this.officerIdNavigation = new OfficerViewModel();

    }

	setProperties(capabilityId : number,officerId : number) : void
	{
		this.capabilityId = capabilityId;
this.officerId = officerId;

	}

	toDisplay() : string
	{
		return String(this.capabilityId);
	}
};

/*<Codenesium>
    <Hash>f9465e13e7e7ab77aa64307a74b04e8d</Hash>
</Codenesium>*/