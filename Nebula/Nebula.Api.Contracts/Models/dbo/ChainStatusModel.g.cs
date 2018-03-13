using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>fe57f225e12b8ed7e078d57c8000b2b2</Hash>
</Codenesium>*/