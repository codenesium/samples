export default class DocumentViewModel {
  changeNumber: number;
  document1: any;
  documentLevel: any;
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

  setProperties(
    changeNumber: number,
    document1: any,
    documentLevel: any,
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
    this.modifiedDate = modifiedDate;
    this.owner = owner;
    this.revision = revision;
    this.rowguid = rowguid;
    this.status = status;
    this.title = title;
  }
}


/*<Codenesium>
    <Hash>8b56974621e8dfc295de58c127337338</Hash>
</Codenesium>*/