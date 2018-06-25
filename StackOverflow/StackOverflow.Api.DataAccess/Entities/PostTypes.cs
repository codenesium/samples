using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowNS.Api.DataAccess
{
        [Table("PostTypes", Schema="dbo")]
        public partial class PostTypes : AbstractEntity
        {
                public PostTypes()
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
    <Hash>ed8df394bd9714f70679a810094cea55</Hash>
</Codenesium>*/