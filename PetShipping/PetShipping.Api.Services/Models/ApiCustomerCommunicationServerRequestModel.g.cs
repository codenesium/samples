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
			string notes)
		{
			this.CustomerId = customerId;
			this.DateCreated = dateCreated;
			this.EmployeeId = employeeId;
			this.Notes = notes;
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
		public string Notes { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>a0eea1bcab7b27a76fe0a7b4c11962b8</Hash>
</Codenesium>*/