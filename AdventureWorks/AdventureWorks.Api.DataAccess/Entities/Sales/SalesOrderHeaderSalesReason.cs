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
		public DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("SalesOrderID")]
		public int SalesOrderID { get; private set; }

		[Column("SalesReasonID")]
		public int SalesReasonID { get; private set; }

		[ForeignKey("SalesOrderID")]
		public virtual SalesOrderHeader SalesOrderHeaderNavigation { get; private set; }

		[ForeignKey("SalesReasonID")]
		public virtual SalesReason SalesReasonNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b0ade050144965b56dd3690d6572cf08</Hash>
</Codenesium>*/