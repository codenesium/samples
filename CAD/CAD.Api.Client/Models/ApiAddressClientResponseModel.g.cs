using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiAddressClientResponseModel : AbstractApiClientResponseModel
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

		[JsonProperty]
		public string Address2 { get; private set; }

		[JsonProperty]
		public string City { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string State { get; private set; }

		[JsonProperty]
		public string Zip { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6c0a1bc90466604658200a69c8329cf1</Hash>
</Codenesium>*/