using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
			string name)
		{
			this.Description = description;
			this.Name = name;
		}

		[Required]
		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>1057dd62aa4439645913485ef3f72c12</Hash>
</Codenesium>*/