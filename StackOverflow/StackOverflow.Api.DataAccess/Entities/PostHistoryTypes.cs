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

                public void SetProperties(
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
    <Hash>dee29d00396b70c3e1438723350f77f9</Hash>
</Codenesium>*/