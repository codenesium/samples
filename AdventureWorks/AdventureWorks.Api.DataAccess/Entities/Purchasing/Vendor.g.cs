using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Vendor", Schema="Purchasing")]
	public partial class Vendor : AbstractEntity
	{
		public Vendor()
		{
		}

		public virtual void SetProperties(
			int businessEntityID,
			string accountNumber,
			bool activeFlag,
			int creditRating,
			DateTime modifiedDate,
			string name,
			bool preferredVendorStatu,
			string purchasingWebServiceURL)
		{
			this.BusinessEntityID = businessEntityID;
			this.AccountNumber = accountNumber;
			this.ActiveFlag = activeFlag;
			this.CreditRating = creditRating;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.PreferredVendorStatu = preferredVendorStatu;
			this.PurchasingWebServiceURL = purchasingWebServiceURL;
		}

		[MaxLength(15)]
		[Column("AccountNumber")]
		public virtual string AccountNumber { get; private set; }

		[Column("ActiveFlag")]
		public virtual bool ActiveFlag { get; private set; }

		[Key]
		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[Column("CreditRating")]
		public virtual int CreditRating { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[Column("PreferredVendorStatus")]
		public virtual bool PreferredVendorStatu { get; private set; }

		[MaxLength(1024)]
		[Column("PurchasingWebServiceURL")]
		public virtual string PurchasingWebServiceURL { get; private set; }
	}
}

/*<Codenesium>
    <Hash>71a19bed7049cc748df75aac897bc555</Hash>
</Codenesium>*/