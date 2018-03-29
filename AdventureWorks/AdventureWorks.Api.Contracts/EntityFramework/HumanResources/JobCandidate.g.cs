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
		public int JobCandidateID {get; set;}
		public Nullable<int> BusinessEntityID {get; set;}
		public string Resume {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFEmployee EmployeeRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>f9df11e7eb864af511a8467588e09294</Hash>
</Codenesium>*/