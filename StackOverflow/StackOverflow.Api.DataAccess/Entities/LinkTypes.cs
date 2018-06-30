using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    <Hash>a4d1631b650d20f0c917e5af44450e25</Hash>
</Codenesium>*/