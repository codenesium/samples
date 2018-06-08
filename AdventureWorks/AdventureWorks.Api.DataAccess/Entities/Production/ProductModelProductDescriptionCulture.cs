using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductModelProductDescriptionCulture", Schema="Production")]
        public partial class ProductModelProductDescriptionCulture: AbstractEntity
        {
                public ProductModelProductDescriptionCulture()
                {
                }

                public void SetProperties(
                        string cultureID,
                        DateTime modifiedDate,
                        int productDescriptionID,
                        int productModelID)
                {
                        this.CultureID = cultureID;
                        this.ModifiedDate = modifiedDate;
                        this.ProductDescriptionID = productDescriptionID;
                        this.ProductModelID = productModelID;
                }

                [Column("CultureID", TypeName="nchar(6)")]
                public string CultureID { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("ProductDescriptionID", TypeName="int")]
                public int ProductDescriptionID { get; private set; }

                [Key]
                [Column("ProductModelID", TypeName="int")]
                public int ProductModelID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>d9b733a869c4adbcbea701b6a8e25c8a</Hash>
</Codenesium>*/