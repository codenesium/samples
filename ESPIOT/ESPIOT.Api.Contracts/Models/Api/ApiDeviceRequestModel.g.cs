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
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public Guid PublicId { get; private set; } = default(Guid);
	}
}

/*<Codenesium>
    <Hash>9d00df55891b04e369f14352b3350cbf</Hash>
</Codenesium>*/