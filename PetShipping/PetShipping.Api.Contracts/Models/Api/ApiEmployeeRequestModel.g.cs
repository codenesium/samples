using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiEmployeeRequestModel : AbstractApiRequestModel
	{
		public ApiEmployeeRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string firstName,
			bool isSalesPerson,
			bool isShipper,
			string lastName)
		{
			this.FirstName = firstName;
			this.IsSalesPerson = isSalesPerson;
			this.IsShipper = isShipper;
			this.LastName = lastName;
		}

		[JsonProperty]
		public string FirstName { get; private set; }

		[JsonProperty]
		public bool IsSalesPerson { get; private set; }

		[JsonProperty]
		public bool IsShipper { get; private set; }

		[JsonProperty]
		public string LastName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8ec1fecb65209e4e65a17e91f60dbf1b</Hash>
</Codenesium>*/