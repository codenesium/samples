using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiClientCommunicationResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			int clientId,
			DateTime dateCreated,
			int employeeId,
			string note)
		{
			this.Id = id;
			this.ClientId = clientId;
			this.DateCreated = dateCreated;
			this.EmployeeId = employeeId;
			this.Note = note;

			this.ClientIdEntity = nameof(ApiResponse.Clients);
			this.EmployeeIdEntity = nameof(ApiResponse.Employees);
		}

		[JsonProperty]
		public int ClientId { get; private set; }

		[JsonProperty]
		public string ClientIdEntity { get; set; }

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
    <Hash>50ce48b694df96aea594a4e6a8d442dd</Hash>
</Codenesium>*/