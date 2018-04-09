using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("SalesOrderHeaderSalesReason", Schema="Sales")]
	public partial class EFSalesOrderHeaderSalesReason
	{
		public EFSalesOrderHeaderSalesReason()
		{}

		public void SetProperties(int salesOrderID,
		                          int salesReasonID,
		                          DateTime modifiedDate)
		{
			this.SalesOrderID = salesOrderID.ToInt();
			this.SalesReasonID = salesReasonID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("SalesOrderID", TypeName="int")]
		public int SalesOrderID {get; set;}

		[Column("SalesReasonID", TypeName="int")]
		public int SalesReasonID {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFSalesOrderHeader SalesOrderHeader { get; set; }

		public virtual EFSalesReason SalesReason { get; set; }
	}
}

/*<Codenesium>
    <Hash>8515989723b1613587d05e384d01b01d</Hash>
</Codenesium>*/