using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FileServiceNS.Api.Contracts
{
	public partial class ApiBucketModel
	{
		public ApiBucketModel()
		{}

		public ApiBucketModel(
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
    <Hash>f919f791fcc7c18fdc6184110f85ff69</Hash>
</Codenesium>*/