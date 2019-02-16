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
			string note)
		{
			this.Id = id;
			this.CustomerId = customerId;
			this.DateCreated = dateCreated;
			this.EmployeeId = employeeId;
			this.Note = note;

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
		public string Note { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3fd4fb0cfc3bfc31c1627569028f7df1</Hash>
</Codenesium>*/