using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiPersonServerResponseModel : AbstractApiServerResponseModel
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

		[Required]
		[JsonProperty]
		public string FirstName { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string LastName { get; private set; }

		[Required]
		[JsonProperty]
		public string Phone { get; private set; }

		[Required]
		[JsonProperty]
		public string Ssn { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0bec634c1e31fcad32183e5bc80b9dd9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/