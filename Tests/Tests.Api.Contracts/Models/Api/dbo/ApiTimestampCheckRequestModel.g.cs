using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
	public partial class ApiTimestampCheckRequestModel : AbstractApiRequestModel
	{
		public ApiTimestampCheckRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name,
			byte[] timestamp)
		{
			this.Name = name;
			this.Timestamp = timestamp;
		}

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public byte[] Timestamp { get; private set; } = default(byte[]);
	}
}

/*<Codenesium>
    <Hash>e2ff377a0022e8c7c9e57e441241bb10</Hash>
</Codenesium>*/