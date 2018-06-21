using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductSubcategory", Schema="Production")]
        public partial class ProductSubcategory : AbstractEntity
        {
                public ProductSubcategory()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        int productCategoryID,
                        int productSubcategoryID,
                        Guid rowguid)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ProductCategoryID = productCategoryID;
                        this.ProductSubcategoryID = productSubcategoryID;
                        this.Rowguid = rowguid;
                }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("ProductCategoryID")]
                public int ProductCategoryID { get; private set; }

                [Key]
                [Column("ProductSubcategoryID")]
                public int ProductSubcategoryID { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>4e3b59c019f5df75cf0b34e8e527c7e2</Hash>
</Codenesium>*/