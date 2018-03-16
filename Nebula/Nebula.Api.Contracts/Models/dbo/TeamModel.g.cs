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

		public TeamModel(POCOTeam poco)
		{
			this.Name = poco.Name;

			this.OrganizationId = poco.OrganizationId.Value.ToInt();
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
    <Hash>778b0e9154d22153406747e9486a3e57</Hash>
</Codenesium>*/