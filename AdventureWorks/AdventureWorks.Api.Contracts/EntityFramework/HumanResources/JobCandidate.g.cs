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
		public int jobCandidateID {get; set;}
		public Nullable<int> businessEntityID {get; set;}
		public string resume {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>e611178951f03a0d2a05cb64c3edd8de</Hash>
</Codenesium>*/