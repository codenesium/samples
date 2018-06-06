using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("JobCandidate", Schema="HumanResources")]
	public partial class JobCandidate: AbstractEntity
	{
		public JobCandidate()
		{}

		public void SetProperties(
			Nullable<int> businessEntityID,
			int jobCandidateID,
			DateTime modifiedDate,
			string resume)
		{
			this.BusinessEntityID = businessEntityID.ToNullableInt();
			this.JobCandidateID = jobCandidateID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Resume = resume;
		}

		[Column("BusinessEntityID", TypeName="int")]
		public Nullable<int> BusinessEntityID { get; private set; }

		[Key]
		[Column("JobCandidateID", TypeName="int")]
		public int JobCandidateID { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("Resume", TypeName="xml(-1)")]
		public string Resume { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b07471a1d0f727f96059774fc0a267f1</Hash>
</Codenesium>*/