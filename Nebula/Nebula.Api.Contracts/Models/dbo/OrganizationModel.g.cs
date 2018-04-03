using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class OrganizationModel
	{
		public OrganizationModel()
		{}
		public OrganizationModel(string name)
		{
			this.Name = name;
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
    <Hash>7fd226ae097a2051d3c6af32c1df5b92</Hash>
</Codenesium>*/