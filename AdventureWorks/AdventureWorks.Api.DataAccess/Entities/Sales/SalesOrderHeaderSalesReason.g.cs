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
			int salesOrderID,
			DateTime modifiedDate,
			int salesReasonID)
		{
			this.SalesOrderID = salesOrderID;
			this.ModifiedDate = modifiedDate;
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
    <Hash>7ac3e751eeb4f4d4f70da04d8200e1b2</Hash>
</Codenesium>*/