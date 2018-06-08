using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductDocument", Schema="Production")]
        public partial class ProductDocument: AbstractEntity
        {
                public ProductDocument()
                {
                }

                public void SetProperties(
                        Guid documentNode,
                        DateTime modifiedDate,
                        int productID)
                {
                        this.DocumentNode = documentNode;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                }

                [Column("DocumentNode", TypeName="hierarchyid(892)")]
                public Guid DocumentNode { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Key]
                [Column("ProductID", TypeName="int")]
                public int ProductID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>88687e0478c7ab5461add54b78e2e9a5</Hash>
</Codenesium>*/