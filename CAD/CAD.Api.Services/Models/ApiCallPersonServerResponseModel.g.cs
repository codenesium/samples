using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiCallPersonServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			string note,
			int personId,
			int personTypeId)
		{
			this.Id = id;
			this.Note = note;
			this.PersonId = personId;
			this.PersonTypeId = personTypeId;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string Note { get; private set; }

		[JsonProperty]
		public int PersonId { get; private set; }

		[JsonProperty]
		public string PersonIdEntity { get; private set; } = RouteConstants.People;

		[JsonProperty]
		public ApiPersonServerResponseModel PersonIdNavigation { get; private set; }

		public void SetPersonIdNavigation(ApiPersonServerResponseModel value)
		{
			this.PersonIdNavigation = value;
		}

		[JsonProperty]
		public int PersonTypeId { get; private set; }

		[JsonProperty]
		public string PersonTypeIdEntity { get; private set; } = RouteConstants.PersonTypes;

		[JsonProperty]
		public ApiPersonTypeServerResponseModel PersonTypeIdNavigation { get; private set; }

		public void SetPersonTypeIdNavigation(ApiPersonTypeServerResponseModel value)
		{
			this.PersonTypeIdNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>42dea2b0087b98d11b384004c2274385</Hash>
</Codenesium>*/