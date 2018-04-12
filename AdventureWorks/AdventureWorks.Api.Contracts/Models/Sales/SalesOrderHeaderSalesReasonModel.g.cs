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
			int salesReasonID,
			DateTime modifiedDate)
		{
			this.SalesReasonID = salesReasonID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
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
	}
}

/*<Codenesium>
    <Hash>ea27f0308651a89e17a7b19c0cf77ad4</Hash>
</Codenesium>*/