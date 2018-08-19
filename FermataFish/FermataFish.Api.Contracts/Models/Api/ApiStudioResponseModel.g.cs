using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiStudioResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			string address1,
			string address2,
			string city,
			string name,
			int stateId,
			string website,
			string zip)
		{
			this.Id = id;
			this.Address1 = address1;
			this.Address2 = address2;
			this.City = city;
			this.Name = name;
			this.StateId = stateId;
			this.Website = website;
			this.Zip = zip;

			this.StateIdEntity = nameof(ApiResponse.States);
		}

		[Required]
		[JsonProperty]
		public string Address1 { get; private set; }

		[Required]
		[JsonProperty]
		public string Address2 { get; private set; }

		[Required]
		[JsonProperty]
		public string City { get; private set; }

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public int StateId { get; private set; }

		[JsonProperty]
		public string StateIdEntity { get; set; }

		[Required]
		[JsonProperty]
		public string Website { get; private set; }

		[Required]
		[JsonProperty]
		public string Zip { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a543d54caa923be9e4bf8580fa0329de</Hash>
</Codenesium>*/