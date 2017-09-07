using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace NebulaNS.Api.Contracts
{
	public partial class LinkStatusModel
	{
		public LinkStatusModel()
		{}

		public LinkStatusModel(int id,
		                       string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		public LinkStatusModel(POCOLinkStatus poco)
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
    <Hash>315ef66640da9bcf39e75aa4a652efc5</Hash>
</Codenesium>*/