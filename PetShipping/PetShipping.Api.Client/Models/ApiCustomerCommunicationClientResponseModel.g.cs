using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiCustomerCommunicationClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			int customerId,
			DateTime dateCreated,
			int employeeId,
			string notes)
		{
			this.Id = id;
			this.CustomerId = customerId;
			this.DateCreated = dateCreated;
			this.EmployeeId = employeeId;
			this.Notes = notes;

			this.CustomerIdEntity = nameof(ApiResponse.Customers);

			this.EmployeeIdEntity = nameof(ApiResponse.Employees);
		}

		[JsonProperty]
		public ApiCustomerClientResponseModel CustomerIdNavigation { get; private set; }

		public void SetCustomerIdNavigation(ApiCustomerClientResponseModel value)
		{
			this.CustomerIdNavigation = value;
		}

		[JsonProperty]
		public ApiEmployeeClientResponseModel EmployeeIdNavigation { get; private set; }

		public void SetEmployeeIdNavigation(ApiEmployeeClientResponseModel value)
		{
			this.EmployeeIdNavigation = value;
		}

		[JsonProperty]
		public int CustomerId { get; private set; }

		[JsonProperty]
		public string CustomerIdEntity { get; set; }

		[JsonProperty]
		public DateTime DateCreated { get; private set; }

		[JsonProperty]
		public int EmployeeId { get; private set; }

		[JsonProperty]
		public string EmployeeIdEntity { get; set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Notes { get; private set; }
	}
}

/*<Codenesium>
    <Hash>27bba9b2b37d27e98633666bb51fe13e</Hash>
</Codenesium>*/