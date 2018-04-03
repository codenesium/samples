using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class TeamModel
	{
		public TeamModel()
		{}
		public TeamModel(string name,
		                 int organizationId)
		{
			this.Name = name;
			this.OrganizationId = organizationId.ToInt();
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

		private int _organizationId;
		[Required]
		public int OrganizationId
		{
			get
			{
				return _organizationId;
			}
			set
			{
				this._organizationId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>dd04af7def8fac8d6ff293e5c1a17faa</Hash>
</Codenesium>*/