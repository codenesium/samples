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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}

		[Column("RateChangeDate", TypeName="datetime")]
		public DateTime RateChangeDate {get; set;}

		[Column("Rate", TypeName="money")]
		public decimal Rate {get; set;}

		[Column("PayFrequency", TypeName="tinyint")]
		public int PayFrequency {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFEmployee Employee { get; set; }
	}
}

/*<Codenesium>
    <Hash>aa281b9c6a95b1f548f5a52a0e989b7f</Hash>
</Codenesium>*/