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
		public int? BusinessEntityID { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("JobCandidateID")]
		public int JobCandidateID { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Column("Resume")]
		public string Resume { get; private set; }
	}
}

/*<Codenesium>
    <Hash>77d6a2248d5af7c5a8003a59fd4e87f9</Hash>
</Codenesium>*/