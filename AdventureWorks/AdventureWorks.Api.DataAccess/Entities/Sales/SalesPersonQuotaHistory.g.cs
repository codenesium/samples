using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesPersonQuotaHistory", Schema="Sales")]
	public partial class SalesPersonQuotaHistory : AbstractEntity
	{
		public SalesPersonQuotaHistory()
		{
		}

		public virtual void SetProperties(
			int businessEntityID,
			DateTime modifiedDate,
			DateTime quotaDate,
			Guid rowguid,
			decimal salesQuota)
		{
			this.BusinessEntityID = businessEntityID;
			this.ModifiedDate = modifiedDate;
			this.QuotaDate = quotaDate;
			this.Rowguid = rowguid;
			this.SalesQuota = salesQuota;
		}

		[Key]
		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("QuotaDate")]
		public virtual DateTime QuotaDate { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[Column("SalesQuota")]
		public virtual decimal SalesQuota { get; private set; }

		[ForeignKey("BusinessEntityID")]
		public virtual SalesPerson BusinessEntityIDNavigation { get; private set; }

		public void SetBusinessEntityIDNavigation(SalesPerson item)
		{
			this.BusinessEntityIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>7d797dfcfcb88d471060d296b26688d8</Hash>
</Codenesium>*/