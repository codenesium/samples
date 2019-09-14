using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class ApiEventStatusServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiEventStatusServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name)
		{
			this.Name = name;
		}

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>cb1f95a4afbb322af618e0f0aa4cc1e7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/