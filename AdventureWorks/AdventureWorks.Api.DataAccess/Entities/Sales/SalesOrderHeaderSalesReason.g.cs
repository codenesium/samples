using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesOrderHeaderSalesReason", Schema="Sales")]
	public partial class SalesOrderHeaderSalesReason : AbstractEntity
	{
		public SalesOrderHeaderSalesReason()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			int salesOrderID,
			int salesReasonID)
		{
			this.ModifiedDate = modifiedDate;
			this.SalesOrderID = salesOrderID;
			this.SalesReasonID = salesReasonID;
		}

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("SalesOrderID")]
		public virtual int SalesOrderID { get; private set; }

		[Key]
		[Column("SalesReasonID")]
		public virtual int SalesReasonID { get; private set; }

		[ForeignKey("SalesOrderID")]
		public virtual SalesOrderHeader SalesOrderHeaderNavigation { get; private set; }

		public void SetSalesOrderHeaderNavigation(SalesOrderHeader item)
		{
			this.SalesOrderHeaderNavigation = item;
		}

		[ForeignKey("SalesReasonID")]
		public virtual SalesReason SalesReasonNavigation { get; private set; }

		public void SetSalesReasonNavigation(SalesReason item)
		{
			this.SalesReasonNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>bf8a98c28ec8218d6318b912f78329b8</Hash>
</Codenesium>*/