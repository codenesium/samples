using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Client
{
	public partial class ApiVenueClientResponseModel : AbstractApiClientResponseModel
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

			this.AdminIdEntity = nameof(ApiResponse.Admins);

			this.ProvinceIdEntity = nameof(ApiResponse.Provinces);
		}

		[JsonProperty]
		public ApiAdminClientResponseModel AdminIdNavigation { get; private set; }

		public void SetAdminIdNavigation(ApiAdminClientResponseModel value)
		{
			this.AdminIdNavigation = value;
		}

		[JsonProperty]
		public ApiProvinceClientResponseModel ProvinceIdNavigation { get; private set; }

		public void SetProvinceIdNavigation(ApiProvinceClientResponseModel value)
		{
			this.ProvinceIdNavigation = value;
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
    <Hash>a53b93a07a2a9a3b2df0689d5e8f4aa1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/