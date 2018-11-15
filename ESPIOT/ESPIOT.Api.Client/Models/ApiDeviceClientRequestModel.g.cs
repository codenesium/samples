using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Client
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
    <Hash>b8a19a0f281058629b239260bb9c1a40</Hash>
</Codenesium>*/