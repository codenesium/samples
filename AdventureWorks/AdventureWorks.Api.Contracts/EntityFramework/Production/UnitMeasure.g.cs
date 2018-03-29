using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("UnitMeasure", Schema="Production")]
	public partial class EFUnitMeasure
	{
		public EFUnitMeasure()
		{}

		[Key]
		public string UnitMeasureCode {get; set;}
		public string Name {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>2e628cd54c0bb7142017f02f79417bbe</Hash>
</Codenesium>*/