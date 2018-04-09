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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}

		[Column("AccountNumber", TypeName="nvarchar(15)")]
		public string AccountNumber {get; set;}

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}

		[Column("CreditRating", TypeName="tinyint")]
		public int CreditRating {get; set;}

		[Column("PreferredVendorStatus", TypeName="bit")]
		public bool PreferredVendorStatus {get; set;}

		[Column("ActiveFlag", TypeName="bit")]
		public bool ActiveFlag {get; set;}

		[Column("PurchasingWebServiceURL", TypeName="nvarchar(1024)")]
		public string PurchasingWebServiceURL {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFBusinessEntity BusinessEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>62016fd1f99ba2b0e37fc414cd630c56</Hash>
</Codenesium>*/