using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesOrderHeaderSalesReason", Schema="Sales")]
	public partial class SalesOrderHeaderSalesReason: AbstractEntityFrameworkDTO
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
    <Hash>b9574981a4d740473587808fb5d54ae9</Hash>
</Codenesium>*/