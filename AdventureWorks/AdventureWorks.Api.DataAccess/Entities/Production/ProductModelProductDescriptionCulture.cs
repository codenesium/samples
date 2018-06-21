using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductModelProductDescriptionCulture", Schema="Production")]
        public partial class ProductModelProductDescriptionCulture : AbstractEntity
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

                [Column("CultureID")]
                public string CultureID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("ProductDescriptionID")]
                public int ProductDescriptionID { get; private set; }

                [Key]
                [Column("ProductModelID")]
                public int ProductModelID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0c0c53c52f1c5fa2412565e1bc1fcbb1</Hash>
</Codenesium>*/