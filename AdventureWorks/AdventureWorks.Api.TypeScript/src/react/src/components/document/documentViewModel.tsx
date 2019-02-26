import moment from 'moment'


export default class DocumentViewModel {
    changeNumber:number;
document1:any;
documentLevel:any;
documentSummary:string;
fileExtension:string;
fileName:string;
folderFlag:boolean;
modifiedDate:any;
owner:number;
revision:string;
rowguid:any;
status:number;
title:string;

    constructor() {
		this.changeNumber = 0;
this.document1 = undefined;
this.documentLevel = undefined;
this.documentSummary = '';
this.fileExtension = '';
this.fileName = '';
this.folderFlag = false;
this.modifiedDate = undefined;
this.owner = 0;
this.revision = '';
this.rowguid = undefined;
this.status = 0;
this.title = '';

    }

	setProperties(changeNumber : number,document1 : any,documentLevel : any,documentSummary : string,fileExtension : string,fileName : string,folderFlag : boolean,modifiedDate : any,owner : number,revision : string,rowguid : any,status : number,title : string) : void
	{
		this.changeNumber = moment(changeNumber,'YYYY-MM-DD');
this.document1 = moment(document1,'YYYY-MM-DD');
this.documentLevel = moment(documentLevel,'YYYY-MM-DD');
this.documentSummary = moment(documentSummary,'YYYY-MM-DD');
this.fileExtension = moment(fileExtension,'YYYY-MM-DD');
this.fileName = moment(fileName,'YYYY-MM-DD');
this.folderFlag = moment(folderFlag,'YYYY-MM-DD');
this.modifiedDate = moment(modifiedDate,'YYYY-MM-DD');
this.owner = moment(owner,'YYYY-MM-DD');
this.revision = moment(revision,'YYYY-MM-DD');
this.rowguid = moment(rowguid,'YYYY-MM-DD');
this.status = moment(status,'YYYY-MM-DD');
this.title = moment(title,'YYYY-MM-DD');

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>a04cb27691a2fce8747b326b10ce1004</Hash>
</Codenesium>*/