using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiEmployeeServerResponseModel : AbstractApiServerResponseModel
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
    <Hash>ea83add6fc362faf63f5de3833bf81cc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/