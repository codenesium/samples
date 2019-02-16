using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Client
{
	public partial class ApiEventClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string address1,
			string address2,
			int cityId,
			DateTime date,
			string description,
			DateTime endDate,
			string facebook,
			string name,
			DateTime startDate,
			string website)
		{
			this.Id = id;
			this.Address1 = address1;
			this.Address2 = address2;
			this.CityId = cityId;
			this.Date = date;
			this.Description = description;
			this.EndDate = endDate;
			this.Facebook = facebook;
			this.Name = name;
			this.StartDate = startDate;
			this.Website = website;

			this.CityIdEntity = nameof(ApiResponse.Cities);
		}

		[JsonProperty]
		public ApiCityClientResponseModel CityIdNavigation { get; private set; }

		public void SetCityIdNavigation(ApiCityClientResponseModel value)
		{
			this.CityIdNavigation = value;
		}

		[JsonProperty]
		public string Address1 { get; private set; }

		[JsonProperty]
		public string Address2 { get; private set; }

		[JsonProperty]
		public int CityId { get; private set; }

		[JsonProperty]
		public string CityIdEntity { get; set; }

		[JsonProperty]
		public DateTime Date { get; private set; }

		[JsonProperty]
		public string Description { get; private set; }

		[JsonProperty]
		public DateTime EndDate { get; private set; }

		[JsonProperty]
		public string Facebook { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public DateTime StartDate { get; private set; }

		[JsonProperty]
		public string Website { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fb059d886b2f8675c63ae0eb4d6f7f20</Hash>
</Codenesium>*/