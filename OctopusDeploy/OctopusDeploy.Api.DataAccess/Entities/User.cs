using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("User", Schema="dbo")]
        public partial class User:AbstractEntity
        {
                public User()
                {
                }

                public void SetProperties(
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

                [Column("DisplayName", TypeName="nvarchar(200)")]
                public string DisplayName { get; private set; }

                [Column("EmailAddress", TypeName="nvarchar(400)")]
                public string EmailAddress { get; private set; }

                [Column("ExternalId", TypeName="nvarchar(400)")]
                public string ExternalId { get; private set; }

                [Column("ExternalIdentifiers", TypeName="nvarchar(-1)")]
                public string ExternalIdentifiers { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("IdentificationToken", TypeName="uniqueidentifier")]
                public Guid IdentificationToken { get; private set; }

                [Column("IsActive", TypeName="bit")]
                public bool IsActive { get; private set; }

                [Column("IsService", TypeName="bit")]
                public bool IsService { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("Username", TypeName="nvarchar(200)")]
                public string Username { get; private set; }
        }
}

/*<Codenesium>
    <Hash>6ea4e6e3eb18ff6645d761472bfc92ef</Hash>
</Codenesium>*/