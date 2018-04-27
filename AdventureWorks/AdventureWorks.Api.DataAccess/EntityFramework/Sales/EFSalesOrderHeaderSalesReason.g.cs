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
		public virtual EFSalesOrderHeader SalesOrderHeader { get; set; }

		[ForeignKey("SalesReasonID")]
		public virtual EFSalesReason SalesReason { get; set; }
	}
}

/*<Codenesium>
    <Hash>7653e23e9a21e697c12d7b5152459ff2</Hash>
</Codenesium>*/