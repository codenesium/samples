using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiEmployeeServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiEmployeeServerRequestModel()
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

		[Required]
		[JsonProperty]
		public string FirstName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public bool IsSalesPerson { get; private set; } = default(bool);

		[Required]
		[JsonProperty]
		public bool IsShipper { get; private set; } = default(bool);

		[Required]
		[JsonProperty]
		public string LastName { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>a02319ea2037b8d17360d23b54d52d7b</Hash>
</Codenesium>*/