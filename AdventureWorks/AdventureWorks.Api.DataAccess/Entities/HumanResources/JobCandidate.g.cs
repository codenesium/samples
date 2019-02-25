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

		[ForeignKey("BusinessEntityID")]
		public virtual Employee BusinessEntityIDNavigation { get; private set; }

		public void SetBusinessEntityIDNavigation(Employee item)
		{
			this.BusinessEntityIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>e18c88b7a15682506c52dba4ab6e7cb1</Hash>
</Codenesium>*/