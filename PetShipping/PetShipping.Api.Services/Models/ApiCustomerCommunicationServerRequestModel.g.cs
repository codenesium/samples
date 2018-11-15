using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiCustomerCommunicationServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiCustomerCommunicationServerRequestModel()
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

		[Required]
		[JsonProperty]
		public int CustomerId { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime DateCreated { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public int EmployeeId { get; private set; }

		[Required]
		[JsonProperty]
		public string Note { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>9622949f7bdb0abb0b90245d3e5ccd11</Hash>
</Codenesium>*/