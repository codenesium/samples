using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Location", Schema="Production")]
	public partial class EFLocation
	{
		public EFLocation()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("LocationID", TypeName="smallint")]
		public short LocationID {get; set;}

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}

		[Column("CostRate", TypeName="smallmoney")]
		public decimal CostRate {get; set;}

		[Column("Availability", TypeName="decimal")]
		public decimal Availability {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>f1549e4b531113ea77faf2bca50eadae</Hash>
</Codenesium>*/