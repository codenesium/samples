using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ScrapReasonModel
	{
		public ScrapReasonModel()
		{}
		public ScrapReasonModel(string name,
		                        DateTime modifiedDate)
		{
			this.Name = name;
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
    <Hash>91a0ac1e04e4166e0ead5d183b02bb93</Hash>
</Codenesium>*/