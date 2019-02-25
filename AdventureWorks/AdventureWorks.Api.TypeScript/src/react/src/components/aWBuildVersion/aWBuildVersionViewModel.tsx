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
    this.database_Version = moment(database_Version, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.systemInformationID = moment(systemInformationID, 'YYYY-MM-DD');
    this.versionDate = moment(versionDate, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>e497d9ccfe8c2acaf6a3f40d71eb929d</Hash>
</Codenesium>*/