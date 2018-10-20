using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
	public partial class ApiProvinceRequestModel : AbstractApiRequestModel
	{
		public ApiProvinceRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int countryId,
			string name)
		{
			this.CountryId = countryId;
			this.Name = name;
		}

		[Required]
		[JsonProperty]
		public int CountryId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>a1c38f320aa1dded880065b5b556e166</Hash>
</Codenesium>*/