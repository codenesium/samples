import moment from 'moment';
import EmployeeViewModel from '../employee/employeeViewModel';

export default class JobCandidateViewModel {
  businessEntityID: number;
  businessEntityIDEntity: string;
  businessEntityIDNavigation?: EmployeeViewModel;
  jobCandidateID: number;
  modifiedDate: any;
  resume: string;

  constructor() {
    this.businessEntityID = 0;
    this.businessEntityIDEntity = '';
    this.businessEntityIDNavigation = undefined;
    this.jobCandidateID = 0;
    this.modifiedDate = undefined;
    this.resume = '';
  }

  setProperties(
    businessEntityID: number,
    jobCandidateID: number,
    modifiedDate: any,
    resume: string
  ): void {
    this.businessEntityID = businessEntityID;
    this.jobCandidateID = jobCandidateID;
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.resume = resume;
  }

  toDisplay(): string {
    return String(this.businessEntityID);
  }
}


/*<Codenesium>
    <Hash>31179f2f21445e20d7c8419710c8fb0f</Hash>
</Codenesium>*/