using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesOrderHeaderSalesReason", Schema="Sales")]
	public partial class SalesOrderHeaderSalesReason: AbstractEntity
	{
		public SalesOrderHeaderSalesReason()
		{}

		public void SetProperties(
			DateTime modifiedDate,
			int salesOrderID,
			int salesReasonID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.SalesOrderID = salesOrderID.ToInt();
			this.SalesReasonID = salesReasonID.ToInt();
		}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("SalesOrderID", TypeName="int")]
		public int SalesOrderID { get; private set; }

		[Column("SalesReasonID", TypeName="int")]
		public int SalesReasonID { get; private set; }

		[ForeignKey("SalesOrderID")]
		public virtual SalesOrderHeader SalesOrderHeader { get; set; }

		[ForeignKey("SalesReasonID")]
		public virtual SalesReason SalesReason { get; set; }
	}
}

/*<Codenesium>
    <Hash>1909e1363e187e988c00b18cc0a4c148</Hash>
</Codenesium>*/