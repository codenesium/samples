using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Client
{
	public partial class ApiTimestampCheckClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiTimestampCheckClientRequestModel()
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

		[JsonProperty]
		public byte[] Timestamp { get; private set; } = default(byte[]);
	}
}

/*<Codenesium>
    <Hash>f807fdf52be5c45af03aebee4a567a15</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/