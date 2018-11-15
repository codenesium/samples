using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Services
{
	public partial class ApiVenueServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
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
			this.Id = id;
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
		public string Address1 { get; private set; }

		[JsonProperty]
		public string Address2 { get; private set; }

		[JsonProperty]
		public int AdminId { get; private set; }

		[JsonProperty]
		public string AdminIdEntity { get; set; }

		[JsonProperty]
		public string Email { get; private set; }

		[JsonProperty]
		public string Facebook { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string Phone { get; private set; }

		[JsonProperty]
		public int ProvinceId { get; private set; }

		[JsonProperty]
		public string ProvinceIdEntity { get; set; }

		[JsonProperty]
		public string Website { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8bb4501cbf09903fa1dbee657c60b3b1</Hash>
</Codenesium>*/