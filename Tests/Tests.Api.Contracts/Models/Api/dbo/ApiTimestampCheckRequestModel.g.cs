using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
    <Hash>61200b7b09246089d2c15b1cc261c987</Hash>
</Codenesium>*/