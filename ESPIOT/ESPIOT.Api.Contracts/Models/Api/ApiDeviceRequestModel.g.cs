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

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public Guid PublicId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a8ee8146320ca271042fd2de5383c731</Hash>
</Codenesium>*/