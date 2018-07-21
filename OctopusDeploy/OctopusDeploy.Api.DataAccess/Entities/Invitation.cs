using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Invitation", Schema="dbo")]
        public partial class Invitation : AbstractEntity
        {
                public Invitation()
                {
                }

                public virtual void SetProperties(
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
    <Hash>a2b7db33699fc9edddfd0de0576b8395</Hash>
</Codenesium>*/