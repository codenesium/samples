using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
        [Table("LinkTypes", Schema="dbo")]
        public partial class LinkTypes : AbstractEntity
        {
                public LinkTypes()
                {
                }

                public virtual void SetProperties(
                        int id,
                        string type)
                {
                        this.Id = id;
                        this.Type = type;
                }

                [Key]
                [Column("Id")]
                public int Id { get; private set; }

                [Column("Type")]
                public string Type { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0fa70ee73783a80e642fb62224315da3</Hash>
</Codenesium>*/