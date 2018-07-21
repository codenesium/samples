using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestsNS.Api.DataAccess
{
        [Table("TimestampCheck", Schema="dbo")]
        public partial class TimestampCheck : AbstractEntity
        {
                public TimestampCheck()
                {
                }

                public virtual void SetProperties(
                        int id,
                        string name,
                        byte[] timestamp)
                {
                        this.Id = id;
                        this.Name = name;
                        this.Timestamp = timestamp;
                }

                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("timestamp")]
                public byte[] Timestamp { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8c4dbc7cda46dbc84789e02ed3d8748e</Hash>
</Codenesium>*/