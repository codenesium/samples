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
    <Hash>2f0e16954bdb36d510c91d476e6147e6</Hash>
</Codenesium>*/