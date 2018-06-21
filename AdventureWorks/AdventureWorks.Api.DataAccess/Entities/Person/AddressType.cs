using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("AddressType", Schema="Person")]
        public partial class AddressType : AbstractEntity
        {
                public AddressType()
                {
                }

                public void SetProperties(
                        int addressTypeID,
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid)
                {
                        this.AddressTypeID = addressTypeID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                }

                [Key]
                [Column("AddressTypeID")]
                public int AddressTypeID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7fd204fe0480229ac3c027d17957b6e0</Hash>
</Codenesium>*/