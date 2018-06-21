using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Invitation", Schema="dbo")]
        public partial class Invitation : AbstractEntity
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
                [Column("Id")]
                public string Id { get; private set; }

                [Column("InvitationCode")]
                public string InvitationCode { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }
        }
}

/*<Codenesium>
    <Hash>456f852da51e71a05e5eadc5fe9c3cd3</Hash>
</Codenesium>*/