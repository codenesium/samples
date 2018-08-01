using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiUserRequestModel : AbstractApiRequestModel
	{
		public ApiUserRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string displayName,
			string emailAddress,
			string externalId,
			string externalIdentifiers,
			Guid identificationToken,
			bool isActive,
			bool isService,
			string jSON,
			string username)
		{
			this.DisplayName = displayName;
			this.EmailAddress = emailAddress;
			this.ExternalId = externalId;
			this.ExternalIdentifiers = externalIdentifiers;
			this.IdentificationToken = identificationToken;
			this.IsActive = isActive;
			this.IsService = isService;
			this.JSON = jSON;
			this.Username = username;
		}

		[JsonProperty]
		public string DisplayName { get; private set; }

		[JsonProperty]
		public string EmailAddress { get; private set; }

		[JsonProperty]
		public string ExternalId { get; private set; }

		[JsonProperty]
		public string ExternalIdentifiers { get; private set; }

		[JsonProperty]
		public Guid IdentificationToken { get; private set; }

		[JsonProperty]
		public bool IsActive { get; private set; }

		[JsonProperty]
		public bool IsService { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string Username { get; private set; }
	}
}

/*<Codenesium>
    <Hash>efe111dcacb1ba10a200542587b4b630</Hash>
</Codenesium>*/