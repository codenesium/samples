using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Contracts
{
	public partial class ApiDeviceRequestModel : AbstractApiRequestModel
	{
		public ApiDeviceRequestModel()
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
		public string Name { get; private set; }

		[JsonProperty]
		public Guid PublicId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ed49338abd60a979c4adf411ee265f38</Hash>
</Codenesium>*/