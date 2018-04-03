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
		public BucketModel(string name,
		                   Guid externalId)
		{
			this.Name = name;
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
    <Hash>5feaaac8f63d3c08b9a8d801820c5f5c</Hash>
</Codenesium>*/