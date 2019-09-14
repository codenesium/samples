using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Services
{
	public partial class ApiRowVersionCheckServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiRowVersionCheckServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name,
			Guid rowVersion)
		{
			this.Name = name;
			this.RowVersion = rowVersion;
		}

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public Guid RowVersion { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>dac370a608bdf40eb3546d1f18cc2847</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/