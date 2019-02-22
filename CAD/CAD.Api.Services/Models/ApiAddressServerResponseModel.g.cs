using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiAddressServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			string address1,
			string address2,
			string city,
			string state,
			string zip)
		{
			this.Id = id;
			this.Address1 = address1;
			this.Address2 = address2;
			this.City = city;
			this.State = state;
			this.Zip = zip;
		}

		[JsonProperty]
		public string Address1 { get; private set; }

		[Required]
		[JsonProperty]
		public string Address2 { get; private set; }

		[JsonProperty]
		public string City { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string State { get; private set; }

		[Required]
		[JsonProperty]
		public string Zip { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f37649ddb206506024fa8d20ced06ea5</Hash>
</Codenesium>*/