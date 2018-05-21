using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesOrderHeaderSalesReasonModel: AbstractModel
	{
		public ApiSalesOrderHeaderSalesReasonModel() : base()
		{}

		public ApiSalesOrderHeaderSalesReasonModel(
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
    <Hash>a6b8ea63fad34067daa3152fb0b961dd</Hash>
</Codenesium>*/