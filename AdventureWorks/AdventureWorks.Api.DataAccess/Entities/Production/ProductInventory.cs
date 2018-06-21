using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductInventory", Schema="Production")]
        public partial class ProductInventory : AbstractEntity
        {
                public ProductInventory()
                {
                }

                public void SetProperties(
                        int bin,
                        short locationID,
                        DateTime modifiedDate,
                        int productID,
                        short quantity,
                        Guid rowguid,
                        string shelf)
                {
                        this.Bin = bin;
                        this.LocationID = locationID;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.Quantity = quantity;
                        this.Rowguid = rowguid;
                        this.Shelf = shelf;
                }

                [Column("Bin")]
                public int Bin { get; private set; }

                [Column("LocationID")]
                public short LocationID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Key]
                [Column("ProductID")]
                public int ProductID { get; private set; }

                [Column("Quantity")]
                public short Quantity { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Column("Shelf")]
                public string Shelf { get; private set; }
        }
}

/*<Codenesium>
    <Hash>476b969b8f65538265a177edc1fba80d</Hash>
</Codenesium>*/