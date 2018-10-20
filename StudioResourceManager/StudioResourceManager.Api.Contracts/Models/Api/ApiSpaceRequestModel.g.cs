using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiSpaceRequestModel : AbstractApiRequestModel
	{
		public ApiSpaceRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string description,
			string name,
			bool isDeleted)
		{
			this.Description = description;
			this.Name = name;
			this.IsDeleted = isDeleted;
		}

		[Required]
		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public bool IsDeleted { get; private set; } = default(bool);
	}
}

/*<Codenesium>
    <Hash>43b2d5c88e45318c54e6acf4b62747d0</Hash>
</Codenesium>*/