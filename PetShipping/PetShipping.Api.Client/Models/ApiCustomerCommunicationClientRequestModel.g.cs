using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiCustomerCommunicationClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiCustomerCommunicationClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int customerId,
			DateTime dateCreated,
			int employeeId,
			string note)
		{
			this.CustomerId = customerId;
			this.DateCreated = dateCreated;
			this.EmployeeId = employeeId;
			this.Note = note;
		}

		[JsonProperty]
		public int CustomerId { get; private set; }

		[JsonProperty]
		public DateTime DateCreated { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int EmployeeId { get; private set; }

		[JsonProperty]
		public string Note { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>50f3a05ace2c2cf3684932c7a4e5560c</Hash>
</Codenesium>*/