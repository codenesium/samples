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
		public int specialOfferID {get; set;}
		public string description {get; set;}
		public decimal discountPct {get; set;}
		public string type {get; set;}
		public string category {get; set;}
		public DateTime startDate {get; set;}
		public DateTime endDate {get; set;}
		public int minQty {get; set;}
		public Nullable<int> maxQty {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>1bc753bf776a1bb60bbb230f9dc94ebc</Hash>
</Codenesium>*/