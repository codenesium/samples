using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Name2 { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>ff15fc9df1d74cf1f03419d3b2810c2e</Hash>
</Codenesium>*/