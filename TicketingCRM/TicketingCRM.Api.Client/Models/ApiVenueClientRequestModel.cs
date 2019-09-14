using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Client
{
	public partial class ApiVenueClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiVenueClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string address1,
			string address2,
			int adminId,
			string email,
			string facebook,
			string name,
			string phone,
			int provinceId,
			string website)
		{
			this.Address1 = address1;
			this.Address2 = address2;
			this.AdminId = adminId;
			this.Email = email;
			this.Facebook = facebook;
			this.Name = name;
			this.Phone = phone;
			this.ProvinceId = provinceId;
			this.Website = website;
		}

		[JsonProperty]
		public string Address1 { get; private set; } = default(string);

		[JsonProperty]
		public string Address2 { get; private set; } = default(string);

		[JsonProperty]
		public int AdminId { get; private set; }

		[JsonProperty]
		public string Email { get; private set; } = default(string);

		[JsonProperty]
		public string Facebook { get; private set; } = default(string);

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public string Phone { get; private set; } = default(string);

		[JsonProperty]
		public int ProvinceId { get; private set; }

		[JsonProperty]
		public string Website { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>9eedc9b56b8c8d39820bc88e605e77b9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/