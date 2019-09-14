using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiPersonClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPersonClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string firstName,
			string lastName,
			string phone,
			string ssn)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Phone = phone;
			this.Ssn = ssn;
		}

		[JsonProperty]
		public string FirstName { get; private set; } = default(string);

		[JsonProperty]
		public string LastName { get; private set; } = default(string);

		[JsonProperty]
		public string Phone { get; private set; } = default(string);

		[JsonProperty]
		public string Ssn { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>0bbefe8dc924182e2f536db6db521cbd</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/