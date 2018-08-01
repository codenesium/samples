using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOUser : AbstractBusinessObject
	{
		public AbstractBOUser()
			: base()
		{
		}

		public virtual void SetProperties(string id,
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
			this.Id = id;
			this.IdentificationToken = identificationToken;
			this.IsActive = isActive;
			this.IsService = isService;
			this.JSON = jSON;
			this.Username = username;
		}

		public string DisplayName { get; private set; }

		public string EmailAddress { get; private set; }

		public string ExternalId { get; private set; }

		public string ExternalIdentifiers { get; private set; }

		public string Id { get; private set; }

		public Guid IdentificationToken { get; private set; }

		public bool IsActive { get; private set; }

		public bool IsService { get; private set; }

		public string JSON { get; private set; }

		public string Username { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b31a0b20c3ff4f3b8009f9594e6ee62e</Hash>
</Codenesium>*/