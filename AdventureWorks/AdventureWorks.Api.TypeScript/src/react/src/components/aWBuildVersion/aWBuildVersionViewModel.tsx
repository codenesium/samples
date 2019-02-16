export default class AWBuildVersionViewModel {
  database_Version: string;
  modifiedDate: any;
  systemInformationID: number;
  versionDate: any;

  constructor() {
    this.database_Version = '';
    this.modifiedDate = undefined;
    this.systemInformationID = 0;
    this.versionDate = undefined;
  }

  setProperties(
    database_Version: string,
    modifiedDate: any,
    systemInformationID: number,
    versionDate: any
  ): void {
    this.database_Version = database_Version;
    this.modifiedDate = modifiedDate;
    this.systemInformationID = systemInformationID;
    this.versionDate = versionDate;
  }
}


/*<Codenesium>
    <Hash>3e47eebeb8a935e3748ac4f60678ec49</Hash>
</Codenesium>*/