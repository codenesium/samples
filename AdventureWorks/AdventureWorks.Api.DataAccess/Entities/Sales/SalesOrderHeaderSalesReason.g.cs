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
		public virtual SalesOrderHeader SalesOrderIDNavigation { get; private set; }

		public void SetSalesOrderIDNavigation(SalesOrderHeader item)
		{
			this.SalesOrderIDNavigation = item;
		}

		[ForeignKey("SalesReasonID")]
		public virtual SalesReason SalesReasonIDNavigation { get; private set; }

		public void SetSalesReasonIDNavigation(SalesReason item)
		{
			this.SalesReasonIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>bfdffa5bb95a3c59f29eb279f4b3ee8e</Hash>
</Codenesium>*/