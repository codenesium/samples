using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Vendor", Schema="Purchasing")]
	public partial class EFVendor
	{
		public EFVendor()
		{}

		[Key]
		public int businessEntityID {get; set;}
		public string accountNumber {get; set;}
		public string name {get; set;}
		public int creditRating {get; set;}
		public bool preferredVendorStatus {get; set;}
		public bool activeFlag {get; set;}
		public string purchasingWebServiceURL {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>5583cc6230c3a0b4e4d682ed0a57f5d5</Hash>
</Codenesium>*/