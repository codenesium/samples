import moment from 'moment'


export default class EmployeeViewModel {
    birthDate:any;
businessEntityID:number;
currentFlag:boolean;
gender:string;
hireDate:any;
jobTitle:string;
loginID:string;
maritalStatu:string;
modifiedDate:any;
nationalIDNumber:string;
organizationLevel:any;
rowguid:any;
salariedFlag:boolean;
sickLeaveHour:number;
vacationHour:number;

    constructor() {
		this.birthDate = undefined;
this.businessEntityID = 0;
this.currentFlag = false;
this.gender = '';
this.hireDate = undefined;
this.jobTitle = '';
this.loginID = '';
this.maritalStatu = '';
this.modifiedDate = undefined;
this.nationalIDNumber = '';
this.organizationLevel = undefined;
this.rowguid = undefined;
this.salariedFlag = false;
this.sickLeaveHour = 0;
this.vacationHour = 0;

    }

	setProperties(birthDate : any,businessEntityID : number,currentFlag : boolean,gender : string,hireDate : any,jobTitle : string,loginID : string,maritalStatu : string,modifiedDate : any,nationalIDNumber : string,organizationLevel : any,rowguid : any,salariedFlag : boolean,sickLeaveHour : number,vacationHour : number) : void
	{
		this.birthDate = moment(birthDate,'YYYY-MM-DD');
this.businessEntityID = moment(businessEntityID,'YYYY-MM-DD');
this.currentFlag = moment(currentFlag,'YYYY-MM-DD');
this.gender = moment(gender,'YYYY-MM-DD');
this.hireDate = moment(hireDate,'YYYY-MM-DD');
this.jobTitle = moment(jobTitle,'YYYY-MM-DD');
this.loginID = moment(loginID,'YYYY-MM-DD');
this.maritalStatu = moment(maritalStatu,'YYYY-MM-DD');
this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.nationalIDNumber = moment(nationalIDNumber,'YYYY-MM-DD');
this.organizationLevel = moment(organizationLevel,'YYYY-MM-DD');
this.rowguid = moment(rowguid,'YYYY-MM-DD');
this.salariedFlag = moment(salariedFlag,'YYYY-MM-DD');
this.sickLeaveHour = moment(sickLeaveHour,'YYYY-MM-DD');
this.vacationHour = moment(vacationHour,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>4266a2a073975618065716f68e74d8d1</Hash>
</Codenesium>*/