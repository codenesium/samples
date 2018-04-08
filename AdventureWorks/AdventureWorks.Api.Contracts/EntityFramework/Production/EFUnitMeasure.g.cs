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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("UnitMeasureCode", TypeName="nchar(3)")]
		public string UnitMeasureCode {get; set;}

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>faf97ec42519b9d172040de9d6f63592</Hash>
</Codenesium>*/