using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.Entity.Spatial;
namespace NebulaNS.Api.Contracts
{
	public partial class OrganizationModel
	{
		public OrganizationModel()
		{}

		public OrganizationModel(int id,
		                         string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		public OrganizationModel(POCOOrganization poco)
		{
			this.Id = poco.Id.ToInt();
			this.Name = poco.Name;
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
	}
}

/*<Codenesium>
    <Hash>cef825343978d79bc332b6d02aa2d0bb</Hash>
</Codenesium>*/