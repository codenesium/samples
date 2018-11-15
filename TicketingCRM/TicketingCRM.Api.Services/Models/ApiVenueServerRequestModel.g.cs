using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Services
{
	public partial class ApiVenueServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiVenueServerRequestModel()
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

		[Required]
		[JsonProperty]
		public string Address1 { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Address2 { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int AdminId { get; private set; }

		[Required]
		[JsonProperty]
		public string Email { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Facebook { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Phone { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int ProvinceId { get; private set; }

		[Required]
		[JsonProperty]
		public string Website { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>5036690013cf49531bd88da87bac770f</Hash>
</Codenesium>*/