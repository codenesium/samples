using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
        [Table("VoteTypes", Schema="dbo")]
        public partial class VoteTypes : AbstractEntity
        {
                public VoteTypes()
                {
                }

                public virtual void SetProperties(
                        int id,
                        string name)
                {
                        this.Id = id;
                        this.Name = name;
                }

                [Key]
                [Column("Id")]
                public int Id { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9e8b4de11bd8236190fc7f4dfdc40f49</Hash>
</Codenesium>*/