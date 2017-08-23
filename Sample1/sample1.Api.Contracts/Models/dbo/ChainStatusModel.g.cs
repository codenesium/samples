using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace sample1NS.Api.Contracts
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
    <Hash>e8a06fd3ed36dc654d4347717f336127</Hash>
</Codenesium>*/