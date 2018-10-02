using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiEmployeeResponseModel : AbstractApiResponseModel
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
    <Hash>6c2d3aa537ea4df9b4a8238c6d6f7101</Hash>
</Codenesium>*/