using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiEmployeeClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiEmployeeClientRequestModel()
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
		public string FirstName { get; private set; } = default(string);

		[JsonProperty]
		public bool IsSalesPerson { get; private set; } = default(bool);

		[JsonProperty]
		public bool IsShipper { get; private set; } = default(bool);

		[JsonProperty]
		public string LastName { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>6274e3c161d87280695c956e1bf53ab0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/