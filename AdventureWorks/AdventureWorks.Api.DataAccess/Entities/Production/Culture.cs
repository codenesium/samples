using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Culture", Schema="Production")]
        public partial class Culture: AbstractEntity
        {
                public Culture()
                {
                }

                public void SetProperties(
                        string cultureID,
                        DateTime modifiedDate,
                        string name)
                {
                        this.CultureID = cultureID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                [Key]
                [Column("CultureID", TypeName="nchar(6)")]
                public string CultureID { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name", TypeName="nvarchar(50)")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8eee543aba3f524ffa1be5baf82005c2</Hash>
</Codenesium>*/