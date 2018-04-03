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
		public string unitMeasureCode {get; set;}
		public string name {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>c9933f674421c5a43749279d061e1e89</Hash>
</Codenesium>*/