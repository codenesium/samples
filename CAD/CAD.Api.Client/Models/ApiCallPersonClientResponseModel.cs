using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiCallPersonClientResponseModel : AbstractApiClientResponseModel
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

			this.PersonIdEntity = nameof(ApiResponse.People);

			this.PersonTypeIdEntity = nameof(ApiResponse.PersonTypes);
		}

		[JsonProperty]
		public ApiPersonClientResponseModel PersonIdNavigation { get; private set; }

		public void SetPersonIdNavigation(ApiPersonClientResponseModel value)
		{
			this.PersonIdNavigation = value;
		}

		[JsonProperty]
		public ApiPersonTypeClientResponseModel PersonTypeIdNavigation { get; private set; }

		public void SetPersonTypeIdNavigation(ApiPersonTypeClientResponseModel value)
		{
			this.PersonTypeIdNavigation = value;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Note { get; private set; }

		[JsonProperty]
		public int PersonId { get; private set; }

		[JsonProperty]
		public string PersonIdEntity { get; set; }

		[JsonProperty]
		public int PersonTypeId { get; private set; }

		[JsonProperty]
		public string PersonTypeIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>ecfe445eeae99c838c49a9944ed62fea</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/