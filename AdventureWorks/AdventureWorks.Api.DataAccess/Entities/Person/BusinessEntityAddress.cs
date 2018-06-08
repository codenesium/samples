using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("BusinessEntityAddress", Schema="Person")]
        public partial class BusinessEntityAddress: AbstractEntity
        {
                public BusinessEntityAddress()
                {
                }

                public void SetProperties(
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

                [Column("AddressID", TypeName="int")]
                public int AddressID { get; private set; }

                [Column("AddressTypeID", TypeName="int")]
                public int AddressTypeID { get; private set; }

                [Key]
                [Column("BusinessEntityID", TypeName="int")]
                public int BusinessEntityID { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("rowguid", TypeName="uniqueidentifier")]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>3c993a51837ffc6b553e923a0c8d6e9d</Hash>
</Codenesium>*/