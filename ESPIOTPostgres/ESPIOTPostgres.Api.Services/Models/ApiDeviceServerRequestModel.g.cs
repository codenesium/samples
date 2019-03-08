using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace ESPIOTPostgresNS.Api.Services
{
	public partial class ApiDeviceServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiDeviceServerRequestModel()
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

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public Guid PublicId { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>1aeef5af1d0a448fb6b0345fa6f575c5</Hash>
</Codenesium>*/