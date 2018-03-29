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
		public int SpecialOfferID {get; set;}
		public string Description {get; set;}
		public decimal DiscountPct {get; set;}
		public string Type {get; set;}
		public string Category {get; set;}
		public DateTime StartDate {get; set;}
		public DateTime EndDate {get; set;}
		public int MinQty {get; set;}
		public Nullable<int> MaxQty {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>d9272cbf3df325f36e70e50c5ce285b1</Hash>
</Codenesium>*/