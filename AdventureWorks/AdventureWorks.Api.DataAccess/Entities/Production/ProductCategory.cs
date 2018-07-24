using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductCategory", Schema="Production")]
        public partial class ProductCategory : AbstractEntity
        {
                public ProductCategory()
                {
                }

                public virtual void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        int productCategoryID,
                        Guid rowguid)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ProductCategoryID = productCategoryID;
                        this.Rowguid = rowguid;
                }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                [Column("ProductCategoryID")]
                public int ProductCategoryID { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("rowguid")]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>fc39da06edefd1444ba118d5b542cc2c</Hash>
</Codenesium>*/