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
		public int BusinessEntityID {get; set;}
		public DateTime RateChangeDate {get; set;}
		public decimal Rate {get; set;}
		public int PayFrequency {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFEmployee EmployeeRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>26ae58dba744f63fdd92f233e425efee</Hash>
</Codenesium>*/