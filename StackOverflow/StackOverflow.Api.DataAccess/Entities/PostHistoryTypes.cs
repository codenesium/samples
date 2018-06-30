using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowNS.Api.DataAccess
{
        [Table("PostHistoryTypes", Schema="dbo")]
        public partial class PostHistoryTypes : AbstractEntity
        {
                public PostHistoryTypes()
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
    <Hash>f0a4ed180a09c624785f06b9dcc1c13c</Hash>
</Codenesium>*/