using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FileServiceNS.Api.Contracts
{
	public partial class ApiBucketModel: AbstractModel
	{
		public ApiBucketModel() : base()
		{}

		public ApiBucketModel(
			Guid externalId,
			string name)
		{
			this.ExternalId = externalId.ToGuid();
			this.Name = name;
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
	}
}

/*<Codenesium>
    <Hash>2cdb19e121d33b3f73f5d4ec21faa67b</Hash>
</Codenesium>*/