using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Vendor", Schema="Purchasing")]
	public partial class EFVendor
	{
		public EFVendor()
		{}

		public void SetProperties(int businessEntityID,
		                          string accountNumber,
		                          string name,
		                          int creditRating,
		                          bool preferredVendorStatus,
		                          bool activeFlag,
		                          string purchasingWebServiceURL,
		                          DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.AccountNumber = accountNumber;
			this.Name = name;
			this.CreditRating = creditRating;
			this.PreferredVendorStatus = preferredVendorStatus;
			this.ActiveFlag = activeFlag;
			this.PurchasingWebServiceURL = purchasingWebServiceURL;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

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
    <Hash>beb9b74ffc0eae51a73ad2e7270dfc0f</Hash>
</Codenesium>*/