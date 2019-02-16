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
    this.errorLine = errorLine;
    this.errorLogID = errorLogID;
    this.errorMessage = errorMessage;
    this.errorNumber = errorNumber;
    this.errorProcedure = errorProcedure;
    this.errorSeverity = errorSeverity;
    this.errorState = errorState;
    this.errorTime = errorTime;
    this.userName = userName;
  }
}


/*<Codenesium>
    <Hash>e52556941cd7dd5c14673e7b769f5bba</Hash>
</Codenesium>*/