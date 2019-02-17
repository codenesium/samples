export default class AWBuildVersionViewModel {
    database_Version:string;
modifiedDate:any;
systemInformationID:number;
versionDate:any;

    constructor() {
		this.database_Version = '';
this.modifiedDate = undefined;
this.systemInformationID = 0;
this.versionDate = undefined;

    }

	setProperties(database_Version : string,modifiedDate : any,systemInformationID : number,versionDate : any) : void
	{
		this.database_Version = database_Version;
this.modifiedDate = modifiedDate;
this.systemInformationID = systemInformationID;
this.versionDate = versionDate;

	}

	toDisplay() : string
	{
		return String();
	}
};

/*<Codenesium>
    <Hash>48ee6d08f16e8160a1755da895f4d2cf</Hash>
</Codenesium>*/