using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("AddressType", Schema="Person")]
        public partial class AddressType: AbstractEntity
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
                [Column("AddressTypeID", TypeName="int")]
                public int AddressTypeID { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name", TypeName="nvarchar(50)")]
                public string Name { get; private set; }

                [Column("rowguid", TypeName="uniqueidentifier")]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9b53a7b78d908528d53fe63d981c1846</Hash>
</Codenesium>*/