using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiPersonServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiPersonServerRequestModel()
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
    <Hash>15253854f9e505d5d8140f3a6ba6479d</Hash>
</Codenesium>*/