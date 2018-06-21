using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Illustration", Schema="Production")]
        public partial class Illustration : AbstractEntity
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

                [Column("Diagram")]
                public string Diagram { get; private set; }

                [Key]
                [Column("IllustrationID")]
                public int IllustrationID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9bdfca1a6320d5b2fff1a0a8534a44e7</Hash>
</Codenesium>*/