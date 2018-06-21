using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("BusinessEntity", Schema="Person")]
        public partial class BusinessEntity : AbstractEntity
        {
                public BusinessEntity()
                {
                }

                public void SetProperties(
                        int businessEntityID,
                        DateTime modifiedDate,
                        Guid rowguid)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                }

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
    <Hash>60a6ade01be74e3f371ff1f5b674b21e</Hash>
</Codenesium>*/