using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Contracts
{
	public partial class ApiFileTypeRequestModel : AbstractApiRequestModel
	{
		public ApiFileTypeRequestModel()
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
    <Hash>b7eee9f635d0d5841f5d9462e5bb9e5d</Hash>
</Codenesium>*/