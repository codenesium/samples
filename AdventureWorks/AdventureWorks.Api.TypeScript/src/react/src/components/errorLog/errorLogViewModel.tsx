import moment from 'moment';

export default class ErrorLogViewModel {
  errorLine: any;
  errorLogID: number;
  errorMessage: string;
  errorNumber: number;
  errorProcedure: string;
  errorSeverity: any;
  errorState: any;
  errorTime: any;
  userName: string;

  constructor() {
    this.errorLine = undefined;
    this.errorLogID = 0;
    this.errorMessage = '';
    this.errorNumber = 0;
    this.errorProcedure = '';
    this.errorSeverity = undefined;
    this.errorState = undefined;
    this.errorTime = undefined;
    this.userName = '';
  }

  setProperties(
    errorLine: any,
    errorLogID: number,
    errorMessage: string,
    errorNumber: number,
    errorProcedure: string,
    errorSeverity: any,
    errorState: any,
    errorTime: any,
    userName: string
  ): void {
    this.errorLine = moment(errorLine, 'YYYY-MM-DD');
    this.errorLogID = moment(errorLogID, 'YYYY-MM-DD');
    this.errorMessage = moment(errorMessage, 'YYYY-MM-DD');
    this.errorNumber = moment(errorNumber, 'YYYY-MM-DD');
    this.errorProcedure = moment(errorProcedure, 'YYYY-MM-DD');
    this.errorSeverity = moment(errorSeverity, 'YYYY-MM-DD');
    this.errorState = moment(errorState, 'YYYY-MM-DD');
    this.errorTime = moment(errorTime, 'YYYY-MM-DD');
    this.userName = moment(userName, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>b0c4b2cc33c534c064ef69df843bb04f</Hash>
</Codenesium>*/