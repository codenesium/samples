using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NebulaNS.Api.DataAccess
{
        [Table("LinkLog", Schema="dbo")]
        public partial class LinkLog : AbstractEntity
        {
                public LinkLog()
                {
                }

                public void SetProperties(
                        DateTime dateEntered,
                        int id,
                        int linkId,
                        string log)
                {
                        this.DateEntered = dateEntered;
                        this.Id = id;
                        this.LinkId = linkId;
                        this.Log = log;
                }

                [Column("dateEntered")]
                public DateTime DateEntered { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("linkId")]
                public int LinkId { get; private set; }

                [Column("log")]
                public string Log { get; private set; }

                [ForeignKey("LinkId")]
                public virtual Link Link { get; set; }
        }
}

/*<Codenesium>
    <Hash>219035bb2fa4e798526fffb993e6a95f</Hash>
</Codenesium>*/