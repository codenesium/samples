using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class LinkStatusModel
	{
		public LinkStatusModel()
		{}

		public LinkStatusModel(string name)
		{
			this.Name = name;
		}

		public LinkStatusModel(POCOLinkStatus poco)
		{
			this.Name = poco.Name;
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
	}
}

/*<Codenesium>
    <Hash>b9d8aaeac9c25240bd4811fc2259c496</Hash>
</Codenesium>*/