using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiClientCommunicationServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiClientCommunicationServerRequestModel()
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
    <Hash>2e60ad392ebf68566a70073d982772c3</Hash>
</Codenesium>*/