using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOJobCandidate: AbstractBusinessObject
        {
                public BOJobCandidate() : base()
                {
                }

                public void SetProperties(int jobCandidateID,
                                          Nullable<int> businessEntityID,
                                          DateTime modifiedDate,
                                          string resume)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.JobCandidateID = jobCandidateID;
                        this.ModifiedDate = modifiedDate;
                        this.Resume = resume;
                }

                public Nullable<int> BusinessEntityID { get; private set; }

                public int JobCandidateID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Resume { get; private set; }
        }
}

/*<Codenesium>
    <Hash>5f709286b85b304f91aaa9a922e97a1e</Hash>
</Codenesium>*/