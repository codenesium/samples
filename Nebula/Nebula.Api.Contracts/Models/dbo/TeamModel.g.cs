using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace NebulaNS.Api.Contracts
{
	public partial class TeamModel
	{
		public TeamModel()
		{}

		public TeamModel(int id,
		                 string name,
		                 int organizationId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.OrganizationId = organizationId.ToInt();
		}

		public TeamModel(POCOTeam poco)
		{
			this.Id = poco.Id.ToInt();
			this.Name = poco.Name;

			OrganizationId = poco.OrganizationId.Value.ToInt();
		}

		private int _id;
		public int Id
		{
			get
			{
				return _id;
			}
			set
			{
				this._id = value;
			}
		}

		private string _name;
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
    <Hash>549e8e5f3e5925d803d8a36540a273fa</Hash>
</Codenesium>*/