using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductDescription", Schema="Production")]
        public partial class ProductDescription : AbstractEntity
        {
                public ProductDescription()
                {
                }

                public void SetProperties(
                        string description,
                        DateTime modifiedDate,
                        int productDescriptionID,
                        Guid rowguid)
                {
                        this.Description = description;
                        this.ModifiedDate = modifiedDate;
                        this.ProductDescriptionID = productDescriptionID;
                        this.Rowguid = rowguid;
                }

                [Column("Description")]
                public string Description { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Key]
                [Column("ProductDescriptionID")]
                public int ProductDescriptionID { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ce2ef52c807745793953128c5abf5015</Hash>
</Codenesium>*/