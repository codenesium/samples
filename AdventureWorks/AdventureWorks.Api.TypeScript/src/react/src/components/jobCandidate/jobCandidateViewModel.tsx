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

  toDisplay(): string {
    return String();
  }
}


/*<Codenesium>
    <Hash>31a59e90f0e7bdfbf8148232489624af</Hash>
</Codenesium>*/