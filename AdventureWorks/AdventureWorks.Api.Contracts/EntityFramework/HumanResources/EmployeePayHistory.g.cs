using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("EmployeePayHistory", Schema="HumanResources")]
	public partial class EFEmployeePayHistory
	{
		public EFEmployeePayHistory()
		{}

		[Key]
		public int businessEntityID {get; set;}
		public DateTime rateChangeDate {get; set;}
		public decimal rate {get; set;}
		public int payFrequency {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>a4b513c8cac28d67f9dc28a73bb5f965</Hash>
</Codenesium>*/