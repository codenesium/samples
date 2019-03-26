import moment from 'moment';

export default class DocumentViewModel {
  changeNumber: number;
  document1: any;
  documentLevel: number;
  documentSummary: string;
  fileExtension: string;
  fileName: string;
  folderFlag: boolean;
  modifiedDate: any;
  owner: number;
  revision: string;
  rowguid: any;
  status: number;
  title: string;

  constructor() {
    this.changeNumber = 0;
    this.document1 = undefined;
    this.documentLevel = 0;
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

  setProperties(
    changeNumber: number,
    document1: any,
    documentLevel: number,
    documentSummary: string,
    fileExtension: string,
    fileName: string,
    folderFlag: boolean,
    modifiedDate: any,
    owner: number,
    revision: string,
    rowguid: any,
    status: number,
    title: string
  ): void {
    this.changeNumber = changeNumber;
    this.document1 = document1;
    this.documentLevel = documentLevel;
    this.documentSummary = documentSummary;
    this.fileExtension = fileExtension;
    this.fileName = fileName;
    this.folderFlag = folderFlag;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.owner = owner;
    this.revision = revision;
    this.rowguid = rowguid;
    this.status = status;
    this.title = title;
  }

  toDisplay(): string {
    return String(this.documentLevel);
  }
}


/*<Codenesium>
    <Hash>8869dba4189f97df53ab41ee28c98d04</Hash>
</Codenesium>*/