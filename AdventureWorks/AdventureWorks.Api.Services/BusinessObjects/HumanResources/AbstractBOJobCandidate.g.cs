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
		                                  int? businessEntityID,
		                                  DateTime modifiedDate,
		                                  string resume)
		{
			this.BusinessEntityID = businessEntityID;
			this.JobCandidateID = jobCandidateID;
			this.ModifiedDate = modifiedDate;
			this.Resume = resume;
		}

		public int? BusinessEntityID { get; private set; }

		public int JobCandidateID { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public string Resume { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1154f56daa4875c0d6e87cd572e5af71</Hash>
</Codenesium>*/