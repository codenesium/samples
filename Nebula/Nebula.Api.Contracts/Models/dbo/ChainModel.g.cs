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

		public ChainModel(
			string name,
			int teamId,
			int chainStatusId,
			Guid externalId)
		{
			this.Name = name;
			this.TeamId = teamId.ToInt();
			this.ChainStatusId = chainStatusId.ToInt();
			this.ExternalId = externalId;
		}

		private string name;

		[Required]
		public string Name
		{
			get
			{
				return this.name;
			}

			set
			{
				this.name = value;
			}
		}

		private int teamId;

		[Required]
		public int TeamId
		{
			get
			{
				return this.teamId;
			}

			set
			{
				this.teamId = value;
			}
		}

		private int chainStatusId;

		[Required]
		public int ChainStatusId
		{
			get
			{
				return this.chainStatusId;
			}

			set
			{
				this.chainStatusId = value;
			}
		}

		private Guid externalId;

		[Required]
		public Guid ExternalId
		{
			get
			{
				return this.externalId;
			}

			set
			{
				this.externalId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>9f1a2ef7b30d7fa3bf35d964f42e26aa</Hash>
</Codenesium>*/