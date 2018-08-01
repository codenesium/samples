using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
	public partial class ApiEventResponseModel : AbstractApiResponseModel
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

		[Required]
		[JsonProperty]
		public string Address1 { get; private set; }

		[Required]
		[JsonProperty]
		public string Address2 { get; private set; }

		[Required]
		[JsonProperty]
		public int CityId { get; private set; }

		[JsonProperty]
		public string CityIdEntity { get; set; }

		[Required]
		[JsonProperty]
		public DateTime Date { get; private set; }

		[Required]
		[JsonProperty]
		public string Description { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime EndDate { get; private set; }

		[Required]
		[JsonProperty]
		public string Facebook { get; private set; }

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime StartDate { get; private set; }

		[Required]
		[JsonProperty]
		public string Website { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7e584aedd411749150d31c028da92b06</Hash>
</Codenesium>*/