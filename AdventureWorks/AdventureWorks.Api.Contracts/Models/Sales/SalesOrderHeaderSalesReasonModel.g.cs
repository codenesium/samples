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

		public SalesOrderHeaderSalesReasonModel(
			DateTime modifiedDate,
			int salesReasonID)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.SalesReasonID = salesReasonID.ToInt();
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}

		private int salesReasonID;

		[Required]
		public int SalesReasonID
		{
			get
			{
				return this.salesReasonID;
			}

			set
			{
				this.salesReasonID = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>86aa75979258a19f6acf86a8e4dcb1f7</Hash>
</Codenesium>*/