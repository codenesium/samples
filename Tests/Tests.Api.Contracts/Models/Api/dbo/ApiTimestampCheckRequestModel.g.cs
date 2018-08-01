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
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public byte[] Timestamp { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5e02599f3d356805a5484eb782f45608</Hash>
</Codenesium>*/