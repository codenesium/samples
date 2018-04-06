using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SpecialOffer", Schema="Sales")]
	public partial class EFSpecialOffer
	{
		public EFSpecialOffer()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("SpecialOfferID", TypeName="int")]
		public int SpecialOfferID {get; set;}
		[Column("Description", TypeName="nvarchar(255)")]
		public string Description {get; set;}
		[Column("DiscountPct", TypeName="smallmoney")]
		public decimal DiscountPct {get; set;}
		[Column("Type", TypeName="nvarchar(50)")]
		public string Type {get; set;}
		[Column("Category", TypeName="nvarchar(50)")]
		public string Category {get; set;}
		[Column("StartDate", TypeName="datetime")]
		public DateTime StartDate {get; set;}
		[Column("EndDate", TypeName="datetime")]
		public DateTime EndDate {get; set;}
		[Column("MinQty", TypeName="int")]
		public int MinQty {get; set;}
		[Column("MaxQty", TypeName="int")]
		public Nullable<int> MaxQty {get; set;}
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>072f7380c6803e21c4b5083cbe5eefd3</Hash>
</Codenesium>*/