using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOJobCandidate : AbstractBusinessObject
        {
                public AbstractBOJobCandidate()
                        : base()
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
    <Hash>c8e936e415b601e33c832574b630db96</Hash>
</Codenesium>*/