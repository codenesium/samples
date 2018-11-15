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
			int? businessEntityID,
			int jobCandidateID,
			DateTime modifiedDate,
			string resume)
		{
			this.BusinessEntityID = businessEntityID;
			this.JobCandidateID = jobCandidateID;
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
    <Hash>75a38a7c19686e04ccb5c4ed36d13823</Hash>
</Codenesium>*/