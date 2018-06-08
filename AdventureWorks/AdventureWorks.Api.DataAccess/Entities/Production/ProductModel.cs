using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductModel", Schema="Production")]
        public partial class ProductModel: AbstractEntity
        {
                public ProductModel()
                {
                }

                public void SetProperties(
                        string catalogDescription,
                        string instructions,
                        DateTime modifiedDate,
                        string name,
                        int productModelID,
                        Guid rowguid)
                {
                        this.CatalogDescription = catalogDescription;
                        this.Instructions = instructions;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ProductModelID = productModelID;
                        this.Rowguid = rowguid;
                }

                [Column("CatalogDescription", TypeName="xml(-1)")]
                public string CatalogDescription { get; private set; }

                [Column("Instructions", TypeName="xml(-1)")]
                public string Instructions { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name", TypeName="nvarchar(50)")]
                public string Name { get; private set; }

                [Key]
                [Column("ProductModelID", TypeName="int")]
                public int ProductModelID { get; private set; }

                [Column("rowguid", TypeName="uniqueidentifier")]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>29daf4e6983999930776eca97e359123</Hash>
</Codenesium>*/