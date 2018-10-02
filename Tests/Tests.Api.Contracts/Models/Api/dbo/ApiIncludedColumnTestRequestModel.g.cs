using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
	public partial class ApiIncludedColumnTestRequestModel : AbstractApiRequestModel
	{
		public ApiIncludedColumnTestRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name,
			string name2)
		{
			this.Name = name;
			this.Name2 = name2;
		}

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public string Name2 { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9136f3577a875bb8c5c22d6985b8e2a5</Hash>
</Codenesium>*/