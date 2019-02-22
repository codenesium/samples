using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiPersonClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string firstName,
			string lastName,
			string phone,
			string ssn)
		{
			this.Id = id;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Phone = phone;
			this.Ssn = ssn;
		}

		[JsonProperty]
		public string FirstName { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string LastName { get; private set; }

		[JsonProperty]
		public string Phone { get; private set; }

		[JsonProperty]
		public string Ssn { get; private set; }
	}
}

/*<Codenesium>
    <Hash>60858ba09a57631602dba0661e4087c9</Hash>
</Codenesium>*/