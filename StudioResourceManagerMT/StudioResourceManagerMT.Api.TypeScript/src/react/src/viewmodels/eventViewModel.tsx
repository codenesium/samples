export default class EventViewModel {
    actualEndDate:any;
actualStartDate:any;
billAmount:any;
eventStatusId:number;
eventStatusIdEntity : string;
id:number;
scheduledEndDate:any;
scheduledStartDate:any;
studentNote:string;
teacherNote:string;

    constructor() {
		this.actualEndDate = undefined;
this.actualStartDate = undefined;
this.billAmount = undefined;
this.eventStatusId = 0;
this.eventStatusIdEntity = '';
this.id = 0;
this.scheduledEndDate = undefined;
this.scheduledStartDate = undefined;
this.studentNote = '';
this.teacherNote = '';

    }

	setProperties(actualEndDate : any,actualStartDate : any,billAmount : any,eventStatusId : number,id : number,isDeleted : boolean,scheduledEndDate : any,scheduledStartDate : any,studentNote : string,teacherNote : string,tenantId : number) : void
	{
		this.actualEndDate = actualEndDate;
this.actualStartDate = actualStartDate;
this.billAmount = billAmount;
this.eventStatusId = eventStatusId;
this.id = id;
this.isDeleted = isDeleted;
this.scheduledEndDate = scheduledEndDate;
this.scheduledStartDate = scheduledStartDate;
this.studentNote = studentNote;
this.teacherNote = teacherNote;
this.tenantId = tenantId;

	}
};

/*<Codenesium>
    <Hash>ee6b92a5689d7391f8a9a6cb91779a1b</Hash>
</Codenesium>*/