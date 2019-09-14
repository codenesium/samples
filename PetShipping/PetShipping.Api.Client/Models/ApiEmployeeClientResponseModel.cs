using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiEmployeeClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string firstName,
			bool isSalesPerson,
			bool isShipper,
			string lastName)
		{
			this.Id = id;
			this.FirstName = firstName;
			this.IsSalesPerson = isSalesPerson;
			this.IsShipper = isShipper;
			this.LastName = lastName;
		}

		[JsonProperty]
		public string FirstName { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public bool IsSalesPerson { get; private set; }

		[JsonProperty]
		public bool IsShipper { get; private set; }

		[JsonProperty]
		public string LastName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8f4dc540bc604d625b10392a09a34836</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/