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
			string notes)
		{
			this.CustomerId = customerId;
			this.DateCreated = dateCreated;
			this.EmployeeId = employeeId;
			this.Notes = notes;
		}

		[JsonProperty]
		public int CustomerId { get; private set; }

		[JsonProperty]
		public DateTime DateCreated { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int EmployeeId { get; private set; }

		[JsonProperty]
		public string Notes { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>c7b68c068e6e5fa67f53c3bfe9b00e11</Hash>
</Codenesium>*/