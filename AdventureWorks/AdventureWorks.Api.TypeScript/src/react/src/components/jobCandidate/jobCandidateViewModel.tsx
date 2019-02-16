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
    this.businessEntityID = businessEntityID;
    this.jobCandidateID = jobCandidateID;
    this.modifiedDate = modifiedDate;
    this.resume = resume;
  }
}


/*<Codenesium>
    <Hash>4b61cdd089828aa98709398095167d4d</Hash>
</Codenesium>*/