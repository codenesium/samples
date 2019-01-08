using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Services
{
	public partial class ApiIncludedColumnTestServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiIncludedColumnTestServerRequestModel()
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
    <Hash>0efdc557f9be8a0d4562e2523906e597</Hash>
</Codenesium>*/