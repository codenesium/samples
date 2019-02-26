import moment from 'moment'


export default class EventViewModel {
    actualEndDate:any;
actualStartDate:any;
billAmount:any;
eventStatusId:number;
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
this.id = 0;
this.scheduledEndDate = undefined;
this.scheduledStartDate = undefined;
this.studentNote = '';
this.teacherNote = '';

    }

	setProperties(actualEndDate : any,actualStartDate : any,billAmount : any,eventStatusId : number,id : number,scheduledEndDate : any,scheduledStartDate : any,studentNote : string,teacherNote : string) : void
	{
		this.actualEndDate = moment(actualEndDate,'YYYY-MM-DD');
this.actualStartDate = moment(actualStartDate,'YYYY-MM-DD');
this.billAmount = moment(billAmount,'YYYY-MM-DD');
this.eventStatusId = moment(eventStatusId,'YYYY-MM-DD');
this.id = moment(id,'YYYY-MM-DD');
this.scheduledEndDate = moment(scheduledEndDate,'YYYY-MM-DD');
this.scheduledStartDate = moment(scheduledStartDate,'YYYY-MM-DD');
this.studentNote = moment(studentNote,'YYYY-MM-DD');
this.teacherNote = moment(teacherNote,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>0efd2fa8b5ce9ab10bdbc037ee86613f</Hash>
</Codenesium>*/