using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesOrderHeaderSalesReason", Schema="Sales")]
	public partial class SalesOrderHeaderSalesReason: AbstractEntityFrameworkPOCO
	{
		public SalesOrderHeaderSalesReason()
		{}

		public void SetProperties(
			int salesOrderID,
			DateTime modifiedDate,
			int salesReasonID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.SalesOrderID = salesOrderID.ToInt();
			this.SalesReasonID = salesReasonID.ToInt();
		}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Key]
		[Column("SalesOrderID", TypeName="int")]
		public int SalesOrderID { get; set; }

		[Column("SalesReasonID", TypeName="int")]
		public int SalesReasonID { get; set; }

		[ForeignKey("SalesOrderID")]
		public virtual SalesOrderHeader SalesOrderHeader { get; set; }

		[ForeignKey("SalesReasonID")]
		public virtual SalesReason SalesReason { get; set; }
	}
}

/*<Codenesium>
    <Hash>9b796000dd3ae2903d6d7a4a0e87fca3</Hash>
</Codenesium>*/