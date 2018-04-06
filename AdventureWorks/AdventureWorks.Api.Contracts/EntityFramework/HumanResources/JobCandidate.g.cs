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
		public virtual EFEmployee EmployeeRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>f7e32af29e499a0bdad12fcc110ec399</Hash>
</Codenesium>*/