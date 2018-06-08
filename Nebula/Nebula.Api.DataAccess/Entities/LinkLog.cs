using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
        [Table("LinkLog", Schema="dbo")]
        public partial class LinkLog: AbstractEntity
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

                [Column("dateEntered", TypeName="datetime")]
                public DateTime DateEntered { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("linkId", TypeName="int")]
                public int LinkId { get; private set; }

                [Column("log", TypeName="text(2147483647)")]
                public string Log { get; private set; }

                [ForeignKey("LinkId")]
                public virtual Link Link { get; set; }
        }
}

/*<Codenesium>
    <Hash>5d7d891fa6eccfd3ae7d4b75a20e9e13</Hash>
</Codenesium>*/