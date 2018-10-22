using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
	public partial class ApiClientCommunicationRequestModel : AbstractApiRequestModel
	{
		public ApiClientCommunicationRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int clientId,
			DateTime dateCreated,
			int employeeId,
			string note)
		{
			this.ClientId = clientId;
			this.DateCreated = dateCreated;
			this.EmployeeId = employeeId;
			this.Note = note;
		}

		[Required]
		[JsonProperty]
		public int ClientId { get; private set; }

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
    <Hash>3f4cdeb1f7ef4a3d3fede3fc6e5265a2</Hash>
</Codenesium>*/