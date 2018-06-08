using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("SalesReason", Schema="Sales")]
        public partial class SalesReason: AbstractEntity
        {
                public SalesReason()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        string reasonType,
                        int salesReasonID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ReasonType = reasonType;
                        this.SalesReasonID = salesReasonID;
                }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name", TypeName="nvarchar(50)")]
                public string Name { get; private set; }

                [Column("ReasonType", TypeName="nvarchar(50)")]
                public string ReasonType { get; private set; }

                [Key]
                [Column("SalesReasonID", TypeName="int")]
                public int SalesReasonID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>575cbcdf6ae14592478dc02de827541d</Hash>
</Codenesium>*/