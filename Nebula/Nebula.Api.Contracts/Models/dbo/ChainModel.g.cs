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

		public ChainModel(string name,
		                  int teamId,
		                  int chainStatusId,
		                  Guid externalId)
		{
			this.Name = name;
			this.TeamId = teamId.ToInt();
			this.ChainStatusId = chainStatusId.ToInt();
			this.ExternalId = externalId;
		}

		public ChainModel(POCOChain poco)
		{
			this.Name = poco.Name;
			this.ExternalId = poco.ExternalId;

			this.TeamId = poco.TeamId.Value.ToInt();
			this.ChainStatusId = poco.ChainStatusId.Value.ToInt();
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
	}
}

/*<Codenesium>
    <Hash>6ba4e218d6d3fb78ef87c19281c7eed8</Hash>
</Codenesium>*/