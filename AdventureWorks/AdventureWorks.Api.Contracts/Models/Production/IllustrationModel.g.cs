using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class IllustrationModel
	{
		public IllustrationModel()
		{}
		public IllustrationModel(string diagram,
		                         DateTime modifiedDate)
		{
			this.Diagram = diagram;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string _diagram;
		public string Diagram
		{
			get
			{
				return _diagram.IsEmptyOrZeroOrNull() ? null : _diagram;
			}
			set
			{
				this._diagram = value;
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
    <Hash>9c35c7c744626551c96a0977eb94f5af</Hash>
</Codenesium>*/