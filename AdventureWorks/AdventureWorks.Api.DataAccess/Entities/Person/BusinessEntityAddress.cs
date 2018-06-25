using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("BusinessEntityAddress", Schema="Person")]
        public partial class BusinessEntityAddress : AbstractEntity
        {
                public BusinessEntityAddress()
                {
                }

                public virtual void SetProperties(
                        int addressID,
                        int addressTypeID,
                        int businessEntityID,
                        DateTime modifiedDate,
                        Guid rowguid)
                {
                        this.AddressID = addressID;
                        this.AddressTypeID = addressTypeID;
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                }

                [Column("AddressID")]
                public int AddressID { get; private set; }

                [Column("AddressTypeID")]
                public int AddressTypeID { get; private set; }

                [Key]
                [Column("BusinessEntityID")]
                public int BusinessEntityID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8580ac1b2c241f6beb84147e4194a69a</Hash>
</Codenesium>*/