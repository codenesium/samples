using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("JobCandidate", Schema="HumanResources")]
	public partial class JobCandidate: AbstractEntityFrameworkPOCO
	{
		public JobCandidate()
		{}

		public void SetProperties(
			int jobCandidateID,
			Nullable<int> businessEntityID,
			DateTime modifiedDate,
			string resume)
		{
			this.BusinessEntityID = businessEntityID.ToNullableInt();
			this.JobCandidateID = jobCandidateID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Resume = resume;
		}

		[Column("BusinessEntityID", TypeName="int")]
		public Nullable<int> BusinessEntityID { get; set; }

		[Key]
		[Column("JobCandidateID", TypeName="int")]
		public int JobCandidateID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Resume", TypeName="xml(-1)")]
		public string Resume { get; set; }
	}
}

/*<Codenesium>
    <Hash>6016a71edf3744a2d6f589898c83a562</Hash>
</Codenesium>*/