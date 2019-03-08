import moment from 'moment'


export default class SelfReferenceViewModel {
    id:number;
selfReferenceId:any;
selfReferenceIdEntity : string;
selfReferenceIdNavigation? : SelfReferenceViewModel;
selfReferenceId2:any;
selfReferenceId2Entity : string;
selfReferenceId2Navigation? : SelfReferenceViewModel;

    constructor() {
		this.id = 0;
this.selfReferenceId = undefined;
this.selfReferenceIdEntity = '';
this.selfReferenceIdNavigation = new SelfReferenceViewModel();
this.selfReferenceId2 = undefined;
this.selfReferenceId2Entity = '';
this.selfReferenceId2Navigation = new SelfReferenceViewModel();

    }

	setProperties(id : number,selfReferenceId : any,selfReferenceId2 : any) : void
	{
		this.id = id;
this.selfReferenceId = selfReferenceId;
this.selfReferenceId2 = selfReferenceId2;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>1742c676dd5145ed3d657715148d5c48</Hash>
</Codenesium>*/