using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Services
{
	public partial class ApiTimestampCheckServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiTimestampCheckServerRequestModel()
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
    <Hash>c9d41801570bee4087eed5d20cf02376</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/