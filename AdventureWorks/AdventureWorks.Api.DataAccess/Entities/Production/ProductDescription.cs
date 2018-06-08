using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductDescription", Schema="Production")]
        public partial class ProductDescription: AbstractEntity
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

                [Column("Description", TypeName="nvarchar(400)")]
                public string Description { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Key]
                [Column("ProductDescriptionID", TypeName="int")]
                public int ProductDescriptionID { get; private set; }

                [Column("rowguid", TypeName="uniqueidentifier")]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>77f8451cb47edcc2bfc03093c9c5cc80</Hash>
</Codenesium>*/