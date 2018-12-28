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
			string note)
		{
			this.Id = id;
			this.CustomerId = customerId;
			this.DateCreated = dateCreated;
			this.EmployeeId = employeeId;
			this.Note = note;
		}

		[JsonProperty]
		public int CustomerId { get; private set; }

		[JsonProperty]
		public string CustomerIdEntity { get; private set; } = RouteConstants.Customers;

		[JsonProperty]
		public DateTime DateCreated { get; private set; }

		[JsonProperty]
		public int EmployeeId { get; private set; }

		[JsonProperty]
		public string EmployeeIdEntity { get; private set; } = RouteConstants.Employees;

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Note { get; private set; }
	}
}

/*<Codenesium>
    <Hash>001bff8cabdc9816e7b6124df782e0e3</Hash>
</Codenesium>*/