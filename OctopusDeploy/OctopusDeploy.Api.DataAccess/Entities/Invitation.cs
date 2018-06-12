using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Invitation", Schema="dbo")]
        public partial class Invitation: AbstractEntity
        {
                public Invitation()
                {
                }

                public void SetProperties(
                        string id,
                        string invitationCode,
                        string jSON)
                {
                        this.Id = id;
                        this.InvitationCode = invitationCode;
                        this.JSON = jSON;
                }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("InvitationCode", TypeName="nvarchar(200)")]
                public string InvitationCode { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e67335f4c4b3e9b8a2a7b7851d161e60</Hash>
</Codenesium>*/