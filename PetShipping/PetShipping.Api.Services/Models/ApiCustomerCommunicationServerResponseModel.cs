using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiCustomerCommunicationServerResponseModel : AbstractApiServerResponseModel
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
		}

		[JsonProperty]
		public int CustomerId { get; private set; }

		[JsonProperty]
		public string CustomerIdEntity { get; private set; } = RouteConstants.Customers;

		[JsonProperty]
		public ApiCustomerServerResponseModel CustomerIdNavigation { get; private set; }

		public void SetCustomerIdNavigation(ApiCustomerServerResponseModel value)
		{
			this.CustomerIdNavigation = value;
		}

		[JsonProperty]
		public DateTime DateCreated { get; private set; }

		[JsonProperty]
		public int EmployeeId { get; private set; }

		[JsonProperty]
		public string EmployeeIdEntity { get; private set; } = RouteConstants.Employees;

		[JsonProperty]
		public ApiEmployeeServerResponseModel EmployeeIdNavigation { get; private set; }

		public void SetEmployeeIdNavigation(ApiEmployeeServerResponseModel value)
		{
			this.EmployeeIdNavigation = value;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Notes { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b8941a99ad43d8f6c0b7d0a16b2ee293</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/