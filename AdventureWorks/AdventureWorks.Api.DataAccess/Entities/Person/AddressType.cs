using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("AddressType", Schema="Person")]
        public partial class AddressType : AbstractEntity
        {
                public AddressType()
                {
                }

                public virtual void SetProperties(
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
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                [Column("AddressTypeID")]
                public int AddressTypeID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("rowguid")]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e3a8ee18e1e9a1f1daa8ec6b9bc94c8f</Hash>
</Codenesium>*/