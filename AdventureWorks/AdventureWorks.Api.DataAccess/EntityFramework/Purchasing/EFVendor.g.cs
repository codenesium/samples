using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Vendor", Schema="Purchasing")]
	public partial class EFVendor: AbstractEntityFrameworkPOCO
	{
		public EFVendor()
		{}

		public void SetProperties(
			int businessEntityID,
			string accountNumber,
			string name,
			int creditRating,
			bool preferredVendorStatus,
			bool activeFlag,
			string purchasingWebServiceURL,
			DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.AccountNumber = accountNumber.ToString();
			this.Name = name.ToString();
			this.CreditRating = creditRating.ToInt();
			this.PreferredVendorStatus = preferredVendorStatus.ToBoolean();
			this.ActiveFlag = activeFlag.ToBoolean();
			this.PurchasingWebServiceURL = purchasingWebServiceURL.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("AccountNumber", TypeName="nvarchar(15)")]
		public string AccountNumber { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("CreditRating", TypeName="tinyint")]
		public int CreditRating { get; set; }

		[Column("PreferredVendorStatus", TypeName="bit")]
		public bool PreferredVendorStatus { get; set; }

		[Column("ActiveFlag", TypeName="bit")]
		public bool ActiveFlag { get; set; }

		[Column("PurchasingWebServiceURL", TypeName="nvarchar(1024)")]
		public string PurchasingWebServiceURL { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("BusinessEntityID")]
		public virtual EFBusinessEntity BusinessEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>58d0719b1a55c384762cea35ddaaded0</Hash>
</Codenesium>*/