using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class ApiSpaceServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiSpaceServerRequestModel()
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
    <Hash>d6ee8a0387bfd58e7d740e6a3b4d9b91</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/