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
			DateTime dateOfLastPing,
			bool isActive,
			string name,
			Guid publicId)
		{
			this.DateOfLastPing = dateOfLastPing;
			this.IsActive = isActive;
			this.Name = name;
			this.PublicId = publicId;
		}

		[JsonProperty]
		public DateTime DateOfLastPing { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public bool IsActive { get; private set; } = default(bool);

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public Guid PublicId { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>11d02a46e6254abf566ed39f87e38051</Hash>
</Codenesium>*/