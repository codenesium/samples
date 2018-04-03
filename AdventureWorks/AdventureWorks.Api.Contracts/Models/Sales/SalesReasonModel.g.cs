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
    <Hash>e912f2095aed3d10483d1cc8269f6d59</Hash>
</Codenesium>*/