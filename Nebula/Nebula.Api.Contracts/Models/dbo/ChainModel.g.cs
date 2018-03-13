using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace NebulaNS.Api.Contracts
{
	public partial class ChainModel
	{
		public ChainModel()
		{}

		public ChainModel(int chainStatusId,
		                  Guid externalId,
		                  int id,
		                  string name,
		                  int teamId)
		{
			this.ChainStatusId = chainStatusId.ToInt();
			this.ExternalId = externalId;
			this.Id = id.ToInt();
			this.Name = name;
			this.TeamId = teamId.ToInt();
		}

		public ChainModel(POCOChain poco)
		{
			this.ExternalId = poco.ExternalId;
			this.Id = poco.Id.ToInt();
			this.Name = poco.Name;

			ChainStatusId = poco.ChainStatusId.Value.ToInt();
			TeamId = poco.TeamId.Value.ToInt();
		}

		private int _chainStatusId;
		public int ChainStatusId
		{
			get
			{
				return _chainStatusId;
			}
			set
			{
				this._chainStatusId = value;
			}
		}

		private Guid _externalId;
		public Guid ExternalId
		{
			get
			{
				return _externalId;
			}
			set
			{
				this._externalId = value;
			}
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

		private int _teamId;
		public int TeamId
		{
			get
			{
				return _teamId;
			}
			set
			{
				this._teamId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>ad625c1e1d85f42e8a14d6c005054beb</Hash>
</Codenesium>*/