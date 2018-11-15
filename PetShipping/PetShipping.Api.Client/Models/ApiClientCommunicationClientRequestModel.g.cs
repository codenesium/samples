using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiClientCommunicationClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiClientCommunicationClientRequestModel()
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

		[JsonProperty]
		public int ClientId { get; private set; }

		[JsonProperty]
		public DateTime DateCreated { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int EmployeeId { get; private set; }

		[JsonProperty]
		public string Note { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>42915ddee58d7d292ea668d62e439c7f</Hash>
</Codenesium>*/