import moment from 'moment';

export default class ErrorLogViewModel {
  errorLine: number;
  errorLogID: number;
  errorMessage: string;
  errorNumber: number;
  errorProcedure: string;
  errorSeverity: number;
  errorState: number;
  errorTime: any;
  userName: string;

  constructor() {
    this.errorLine = 0;
    this.errorLogID = 0;
    this.errorMessage = '';
    this.errorNumber = 0;
    this.errorProcedure = '';
    this.errorSeverity = 0;
    this.errorState = 0;
    this.errorTime = undefined;
    this.userName = '';
  }

  setProperties(
    errorLine: number,
    errorLogID: number,
    errorMessage: string,
    errorNumber: number,
    errorProcedure: string,
    errorSeverity: number,
    errorState: number,
    errorTime: any,
    userName: string
  ): void {
    this.errorLine = errorLine;
    this.errorLogID = errorLogID;
    this.errorMessage = errorMessage;
    this.errorNumber = errorNumber;
    this.errorProcedure = errorProcedure;
    this.errorSeverity = errorSeverity;
    this.errorState = errorState;
    this.errorTime = moment(errorTime, 'YYYY-MM-DD');
    this.userName = userName;
  }

  toDisplay(): string {
    return String(this.errorLine);
  }
}


/*<Codenesium>
    <Hash>c9632e8a6fa7ea0a032deb5733ce6c2e</Hash>
</Codenesium>*/