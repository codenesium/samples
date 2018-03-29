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
		public int BusinessEntityID {get; set;}
		public string AccountNumber {get; set;}
		public string Name {get; set;}
		public int CreditRating {get; set;}
		public bool PreferredVendorStatus {get; set;}
		public bool ActiveFlag {get; set;}
		public string PurchasingWebServiceURL {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFBusinessEntity BusinessEntityRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>d7736a7439ce53f200db1deec518af66</Hash>
</Codenesium>*/