using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace ESPIOTPostgresNS.Api.Client
{
	public partial class ApiDeviceClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiDeviceClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name,
			Guid publicId)
		{
			this.Name = name;
			this.PublicId = publicId;
		}

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public Guid PublicId { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>6945505986c7dc30a4d6d9b8670d0a3c</Hash>
</Codenesium>*/