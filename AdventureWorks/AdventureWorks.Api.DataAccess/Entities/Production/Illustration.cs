using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Illustration", Schema="Production")]
        public partial class Illustration: AbstractEntity
        {
                public Illustration()
                {
                }

                public void SetProperties(
                        string diagram,
                        int illustrationID,
                        DateTime modifiedDate)
                {
                        this.Diagram = diagram;
                        this.IllustrationID = illustrationID;
                        this.ModifiedDate = modifiedDate;
                }

                [Column("Diagram", TypeName="xml(-1)")]
                public string Diagram { get; private set; }

                [Key]
                [Column("IllustrationID", TypeName="int")]
                public int IllustrationID { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>437ada375ac270bcb8b8752bb246daf8</Hash>
</Codenesium>*/