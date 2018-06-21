using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NebulaNS.Api.DataAccess
{
        [Table("Chain", Schema="dbo")]
        public partial class Chain : AbstractEntity
        {
                public Chain()
                {
                }

                public void SetProperties(
                        int chainStatusId,
                        Guid externalId,
                        int id,
                        string name,
                        int teamId)
                {
                        this.ChainStatusId = chainStatusId;
                        this.ExternalId = externalId;
                        this.Id = id;
                        this.Name = name;
                        this.TeamId = teamId;
                }

                [Column("chainStatusId")]
                public int ChainStatusId { get; private set; }

                [Column("externalId")]
                public Guid ExternalId { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }

                [Column("teamId")]
                public int TeamId { get; private set; }

                [ForeignKey("ChainStatusId")]
                public virtual ChainStatus ChainStatus { get; set; }

                [ForeignKey("TeamId")]
                public virtual Team Team { get; set; }
        }
}

/*<Codenesium>
    <Hash>f28b8719ae55a2145fd2c65164e54e65</Hash>
</Codenesium>*/