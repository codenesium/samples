using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class SalesOrderHeaderSalesReasonModel
	{
		public SalesOrderHeaderSalesReasonModel()
		{}

		public SalesOrderHeaderSalesReasonModel(int salesReasonID,
		                                        DateTime modifiedDate)
		{
			this.SalesReasonID = salesReasonID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public SalesOrderHeaderSalesReasonModel(POCOSalesOrderHeaderSalesReason poco)
		{
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.SalesReasonID = poco.SalesReasonID.Value.ToInt();
		}

		private int _salesReasonID;
		[Required]
		public int SalesReasonID
		{
			get
			{
				return _salesReasonID;
			}
			set
			{
				this._salesReasonID = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>ec97ed72aa84e31f433e71015a49d62b</Hash>
</Codenesium>*/