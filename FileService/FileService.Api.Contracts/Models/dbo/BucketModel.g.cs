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

		public BucketModel(Guid externalId,
		                   string name)
		{
			this.ExternalId = externalId;
			this.Name = name;
		}

		public BucketModel(POCOBucket poco)
		{
			this.ExternalId = poco.ExternalId;
			this.Name = poco.Name;
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
	}
}

/*<Codenesium>
    <Hash>44b487d533d1393ff0f58d147ab63315</Hash>
</Codenesium>*/