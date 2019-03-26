import moment from 'moment';

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
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.systemInformationID = systemInformationID;
    this.versionDate = moment(versionDate, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String(this.databaseVersion);
  }
}


/*<Codenesium>
    <Hash>1ec110026b38a3a3fb75d5a0fc74b053</Hash>
</Codenesium>*/