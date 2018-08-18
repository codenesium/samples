using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("User", Schema="dbo")]
	public partial class User : AbstractEntity
	{
		public User()
		{
		}

		public virtual void SetProperties(
			string displayName,
			string emailAddress,
			string externalId,
			string externalIdentifiers,
			string id,
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

		[MaxLength(200)]
		[Column("DisplayName")]
		public string DisplayName { get; private set; }

		[MaxLength(400)]
		[Column("EmailAddress")]
		public string EmailAddress { get; private set; }

		[MaxLength(400)]
		[Column("ExternalId")]
		public string ExternalId { get; private set; }

		[Column("ExternalIdentifiers")]
		public string ExternalIdentifiers { get; private set; }

		[Key]
		[MaxLength(50)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("IdentificationToken")]
		public Guid IdentificationToken { get; private set; }

		[Column("IsActive")]
		public bool IsActive { get; private set; }

		[Column("IsService")]
		public bool IsService { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[MaxLength(200)]
		[Column("Username")]
		public string Username { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7cd2b1807f7ec8afe710f23f463509a3</Hash>
</Codenesium>*/