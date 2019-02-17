export default class ShiftViewModel {
    endTime:any;
modifiedDate:any;
name:string;
shiftID:number;
startTime:any;

    constructor() {
		this.endTime = undefined;
this.modifiedDate = undefined;
this.name = '';
this.shiftID = 0;
this.startTime = undefined;

    }

	setProperties(endTime : any,modifiedDate : any,name : string,shiftID : number,startTime : any) : void
	{
		this.endTime = endTime;
this.modifiedDate = modifiedDate;
this.name = name;
this.shiftID = shiftID;
this.startTime = startTime;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>f8dfba458887dff0fc88bd531edf00e9</Hash>
</Codenesium>*/