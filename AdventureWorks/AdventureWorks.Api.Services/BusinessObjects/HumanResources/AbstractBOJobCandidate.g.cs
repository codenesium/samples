using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOJobCandidate: AbstractBusinessObject
        {
                public AbstractBOJobCandidate() : base()
                {
                }

                public virtual void SetProperties(int jobCandidateID,
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
    <Hash>c49810aa35a730ea5f5bcf50718111c8</Hash>
</Codenesium>*/