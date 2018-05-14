using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Vendor", Schema="Purchasing")]
	public partial class Vendor:AbstractEntityFrameworkPOCO
	{
		public Vendor()
		{}

		public void SetProperties(
			int businessEntityID,
			string accountNumber,
			bool activeFlag,
			int creditRating,
			DateTime modifiedDate,
			string name,
			bool preferredVendorStatus,
			string purchasingWebServiceURL)
		{
			this.AccountNumber = accountNumber.ToString();
			this.ActiveFlag = activeFlag.ToBoolean();
			this.BusinessEntityID = businessEntityID.ToInt();
			this.CreditRating = creditRating.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.PreferredVendorStatus = preferredVendorStatus.ToBoolean();
			this.PurchasingWebServiceURL = purchasingWebServiceURL.ToString();
		}

		[Column("AccountNumber", TypeName="nvarchar(15)")]
		public string AccountNumber { get; set; }

		[Column("ActiveFlag", TypeName="bit")]
		public bool ActiveFlag { get; set; }

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("CreditRating", TypeName="tinyint")]
		public int CreditRating { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("PreferredVendorStatus", TypeName="bit")]
		public bool PreferredVendorStatus { get; set; }

		[Column("PurchasingWebServiceURL", TypeName="nvarchar(1024)")]
		public string PurchasingWebServiceURL { get; set; }
	}
}

/*<Codenesium>
    <Hash>b8d3325258efee999f882df68dda76f7</Hash>
</Codenesium>*/