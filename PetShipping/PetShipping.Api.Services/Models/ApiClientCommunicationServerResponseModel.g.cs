using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiClientCommunicationServerResponseModel : AbstractApiServerResponseModel
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
    <Hash>b366641e18752f1c3a24b2f5f12a62cf</Hash>
</Codenesium>*/