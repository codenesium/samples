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
			string note)
		{
			this.ClientId = clientId;
			this.DateCreated = dateCreated;
			this.EmployeeId = employeeId;
			this.Note = note;
		}

		[Required]
		[JsonProperty]
		public int ClientId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime DateCreated { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int EmployeeId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string Note { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>a37feef60f7b8ceb711fd202a152c993</Hash>
</Codenesium>*/