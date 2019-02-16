using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("JobCandidate", Schema="HumanResources")]
	public partial class JobCandidate : AbstractEntity
	{
		public JobCandidate()
		{
		}

		public virtual void SetProperties(
			int jobCandidateID,
			int? businessEntityID,
			DateTime modifiedDate,
			string resume)
		{
			this.JobCandidateID = jobCandidateID;
			this.BusinessEntityID = businessEntityID;
			this.ModifiedDate = modifiedDate;
			this.Resume = resume;
		}

		[Column("BusinessEntityID")]
		public virtual int? BusinessEntityID { get; private set; }

		[Key]
		[Column("JobCandidateID")]
		public virtual int JobCandidateID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("Resume")]
		public virtual string Resume { get; private set; }
	}
}

/*<Codenesium>
    <Hash>706b1fcf8f1d91796f816b1642361df6</Hash>
</Codenesium>*/