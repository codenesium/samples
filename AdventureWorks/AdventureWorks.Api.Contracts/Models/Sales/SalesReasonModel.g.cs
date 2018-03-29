using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class SalesReasonModel
	{
		public SalesReasonModel()
		{}

		public SalesReasonModel(string name,
		                        string reasonType,
		                        DateTime modifiedDate)
		{
			this.Name = name;
			this.ReasonType = reasonType;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public SalesReasonModel(POCOSalesReason poco)
		{
			this.Name = poco.Name;
			this.ReasonType = poco.ReasonType;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();
		}

		private string _name;
		[Required]
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				this._name = value;
			}
		}

		private string _reasonType;
		[Required]
		public string ReasonType
		{
			get
			{
				return _reasonType;
			}
			set
			{
				this._reasonType = value;
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
    <Hash>892e7e1a96888874937d2546f3634ed8</Hash>
</Codenesium>*/