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

		public BucketModel(POCOBucket poco)
		{
			this.Name = poco.Name;
			this.ExternalId = poco.ExternalId;
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
    <Hash>e1ab54fc1097bb7ffa7b15c2224dd0b4</Hash>
</Codenesium>*/