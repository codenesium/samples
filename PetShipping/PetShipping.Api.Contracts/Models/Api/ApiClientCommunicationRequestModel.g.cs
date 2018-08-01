using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
			string notes)
		{
			this.ClientId = clientId;
			this.DateCreated = dateCreated;
			this.EmployeeId = employeeId;
			this.Notes = notes;
		}

		[JsonProperty]
		public int ClientId { get; private set; }

		[JsonProperty]
		public DateTime DateCreated { get; private set; }

		[JsonProperty]
		public int EmployeeId { get; private set; }

		[JsonProperty]
		public string Notes { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cf3d1f828f3d93a1410d027f81eeaa89</Hash>
</Codenesium>*/