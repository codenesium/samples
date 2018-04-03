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
    <Hash>bb2753bffe819dfa788f8d4e34fd33de</Hash>
</Codenesium>*/