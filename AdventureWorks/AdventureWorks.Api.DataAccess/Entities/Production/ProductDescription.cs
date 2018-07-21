using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductDescription", Schema="Production")]
        public partial class ProductDescription : AbstractEntity
        {
                public ProductDescription()
                {
                }

                public virtual void SetProperties(
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
    <Hash>251ef67387c9a67c7ffc947a4fb5981a</Hash>
</Codenesium>*/