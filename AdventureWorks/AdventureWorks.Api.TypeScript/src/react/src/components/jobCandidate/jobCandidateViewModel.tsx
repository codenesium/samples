import moment from 'moment';

export default class JobCandidateViewModel {
  businessEntityID: any;
  jobCandidateID: number;
  modifiedDate: any;
  resume: string;

  constructor() {
    this.businessEntityID = undefined;
    this.jobCandidateID = 0;
    this.modifiedDate = undefined;
    this.resume = '';
  }

  setProperties(
    businessEntityID: any,
    jobCandidateID: number,
    modifiedDate: any,
    resume: string
  ): void {
    this.businessEntityID = moment(businessEntityID, 'YYYY-MM-DD');
    this.jobCandidateID = moment(jobCandidateID, 'YYYY-MM-DD');
    this.modifiedDate = moment(modifiedDate, 'YYYY-MM-DD');
    this.resume = moment(resume, 'YYYY-MM-DD');
  }

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>40805b183316ad8a4c666c6277de5a65</Hash>
</Codenesium>*/