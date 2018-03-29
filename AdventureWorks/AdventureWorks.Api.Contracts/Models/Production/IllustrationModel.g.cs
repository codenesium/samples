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

		public IllustrationModel(POCOIllustration poco)
		{
			this.Diagram = poco.Diagram;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();
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
    <Hash>99554818cd8e9e1c0bcf4bb9db1eae58</Hash>
</Codenesium>*/