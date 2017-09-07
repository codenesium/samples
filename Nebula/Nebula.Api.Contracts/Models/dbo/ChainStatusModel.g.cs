using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace NebulaNS.Api.Contracts
{
	public partial class ChainStatusModel
	{
		public ChainStatusModel()
		{}

		public ChainStatusModel(int id,
		                        string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		public ChainStatusModel(POCOChainStatus poco)
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
    <Hash>8cb37ccff9b07bc98f0664a39d6301bd</Hash>
</Codenesium>*/