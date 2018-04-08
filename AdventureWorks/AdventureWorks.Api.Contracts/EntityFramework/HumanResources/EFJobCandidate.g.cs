using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("JobCandidate", Schema="HumanResources")]
	public partial class EFJobCandidate
	{
		public EFJobCandidate()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("JobCandidateID", TypeName="int")]
		public int JobCandidateID {get; set;}

		[Column("BusinessEntityID", TypeName="int")]
		public Nullable<int> BusinessEntityID {get; set;}

		[Column("Resume", TypeName="xml(-1)")]
		public string Resume {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFEmployee Employee { get; set; }
	}
}

/*<Codenesium>
    <Hash>e71ba9415ad648167fc7e2cd89d1a798</Hash>
</Codenesium>*/