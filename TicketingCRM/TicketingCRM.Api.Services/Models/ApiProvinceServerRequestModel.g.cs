using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Services
{
	public partial class ApiProvinceServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiProvinceServerRequestModel()
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
		public int CountryId { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>b267e6b3f9ed3051e539b5e94645567f</Hash>
</Codenesium>*/