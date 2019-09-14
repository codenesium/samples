using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Services
{
	public partial class ApiEventServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiEventServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
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
		}

		[Required]
		[JsonProperty]
		public string Address1 { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Address2 { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int CityId { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime Date { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string Description { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime EndDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string Facebook { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime StartDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string Website { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>f78ffa2f4db53dde1bbd54f1970bb864</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/