using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Vendor", Schema="Purchasing")]
	public partial class Vendor:AbstractEntity
	{
		public Vendor()
		{}

		public void SetProperties(
			string accountNumber,
			bool activeFlag,
			int businessEntityID,
			int creditRating,
			DateTime modifiedDate,
			string name,
			bool preferredVendorStatus,
			string purchasingWebServiceURL)
		{
			this.AccountNumber = accountNumber;
			this.ActiveFlag = activeFlag.ToBoolean();
			this.BusinessEntityID = businessEntityID.ToInt();
			this.CreditRating = creditRating.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.PreferredVendorStatus = preferredVendorStatus.ToBoolean();
			this.PurchasingWebServiceURL = purchasingWebServiceURL;
		}

		[Column("AccountNumber", TypeName="nvarchar(15)")]
		public string AccountNumber { get; private set; }

		[Column("ActiveFlag", TypeName="bit")]
		public bool ActiveFlag { get; private set; }

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; private set; }

		[Column("CreditRating", TypeName="tinyint")]
		public int CreditRating { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; private set; }

		[Column("PreferredVendorStatus", TypeName="bit")]
		public bool PreferredVendorStatus { get; private set; }

		[Column("PurchasingWebServiceURL", TypeName="nvarchar(1024)")]
		public string PurchasingWebServiceURL { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cf1dbfaa51b82955809d8a7429333a95</Hash>
</Codenesium>*/