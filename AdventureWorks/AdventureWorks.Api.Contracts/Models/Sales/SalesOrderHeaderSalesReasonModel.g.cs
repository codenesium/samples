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
    <Hash>b241fa8f9c6e5a9bb42505b4863215cc</Hash>
</Codenesium>*/