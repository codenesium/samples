using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("JobCandidate", Schema="HumanResources")]
	public partial class EFJobCandidate: AbstractEntityFrameworkPOCO
	{
		public EFJobCandidate()
		{}

		public void SetProperties(
			int jobCandidateID,
			Nullable<int> businessEntityID,
			string resume,
			DateTime modifiedDate)
		{
			this.JobCandidateID = jobCandidateID.ToInt();
			this.BusinessEntityID = businessEntityID.ToNullableInt();
			this.Resume = resume;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("JobCandidateID", TypeName="int")]
		public int JobCandidateID { get; set; }

		[Column("BusinessEntityID", TypeName="int")]
		public Nullable<int> BusinessEntityID { get; set; }

		[Column("Resume", TypeName="xml(-1)")]
		public string Resume { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("BusinessEntityID")]
		public virtual EFEmployee Employee { get; set; }
	}
}

/*<Codenesium>
    <Hash>6f67392109c52c82d4d7fb6de753a282</Hash>
</Codenesium>*/