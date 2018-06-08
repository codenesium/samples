using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductSubcategory", Schema="Production")]
        public partial class ProductSubcategory: AbstractEntity
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

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name", TypeName="nvarchar(50)")]
                public string Name { get; private set; }

                [Column("ProductCategoryID", TypeName="int")]
                public int ProductCategoryID { get; private set; }

                [Key]
                [Column("ProductSubcategoryID", TypeName="int")]
                public int ProductSubcategoryID { get; private set; }

                [Column("rowguid", TypeName="uniqueidentifier")]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a8aeee24fa14fdbcdf156827af0bf112</Hash>
</Codenesium>*/