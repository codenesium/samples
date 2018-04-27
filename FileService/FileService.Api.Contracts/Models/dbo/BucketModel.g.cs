using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FileServiceNS.Api.Contracts
{
	public partial class BucketModel
	{
		public BucketModel()
		{}

		public BucketModel(
			Guid externalId,
			string name)
		{
			this.ExternalId = externalId.ToGuid();
			this.Name = name.ToString();
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
    <Hash>076e3531924617314569c6292b124f1e</Hash>
</Codenesium>*/