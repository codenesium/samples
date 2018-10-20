using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiEventStatusRequestModel : AbstractApiRequestModel
	{
		public ApiEventStatusRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name,
			bool isDeleted)
		{
			this.Name = name;
			this.IsDeleted = isDeleted;
		}

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public bool IsDeleted { get; private set; } = default(bool);
	}
}

/*<Codenesium>
    <Hash>f18f8ad8270a178dde0912c60d2e6345</Hash>
</Codenesium>*/