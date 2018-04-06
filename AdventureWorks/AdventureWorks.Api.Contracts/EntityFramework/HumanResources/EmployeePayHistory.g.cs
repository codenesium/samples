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

		[ForeignKey("BusinessEntityID")]
		public virtual EFEmployee EmployeeRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>0c39bdcc7cd1baa38b5f956c31b44d79</Hash>
</Codenesium>*/