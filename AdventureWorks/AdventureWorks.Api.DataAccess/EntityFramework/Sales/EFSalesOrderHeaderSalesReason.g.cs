using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesOrderHeaderSalesReason", Schema="Sales")]
	public partial class EFSalesOrderHeaderSalesReason: AbstractEntityFrameworkPOCO
	{
		public EFSalesOrderHeaderSalesReason()
		{}

		public void SetProperties(
			int salesOrderID,
			int salesReasonID,
			DateTime modifiedDate)
		{
			this.SalesOrderID = salesOrderID.ToInt();
			this.SalesReasonID = salesReasonID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("SalesOrderID", TypeName="int")]
		public int SalesOrderID { get; set; }

		[Column("SalesReasonID", TypeName="int")]
		public int SalesReasonID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("SalesOrderID")]
		public virtual EFSalesOrderHeader SalesOrderHeader { get; set; }

		[ForeignKey("SalesReasonID")]
		public virtual EFSalesReason SalesReason { get; set; }
	}
}

/*<Codenesium>
    <Hash>d5f4952d587813f52c9be76eeb2665f2</Hash>
</Codenesium>*/