using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ChainModel
	{
		public ChainModel()
		{}

		public ChainModel(int chainStatusId,
		                  Guid externalId,
		                  string name,
		                  int teamId)
		{
			this.ChainStatusId = chainStatusId.ToInt();
			this.ExternalId = externalId;
			this.Name = name;
			this.TeamId = teamId.ToInt();
		}

		public ChainModel(POCOChain poco)
		{
			this.ExternalId = poco.ExternalId;
			this.Name = poco.Name;

			this.ChainStatusId = poco.ChainStatusId.Value.ToInt();
			this.TeamId = poco.TeamId.Value.ToInt();
		}

		private int _chainStatusId;
		[Required]
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
		[Required]
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

		private int _teamId;
		[Required]
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
    <Hash>d174e8e56ff15835f55e1634a019258e</Hash>
</Codenesium>*/