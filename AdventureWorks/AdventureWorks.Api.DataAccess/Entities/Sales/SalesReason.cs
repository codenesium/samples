using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("SalesReason", Schema="Sales")]
        public partial class SalesReason : AbstractEntity
        {
                public SalesReason()
                {
                }

                public virtual void SetProperties(
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

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("ReasonType")]
                public string ReasonType { get; private set; }

                [Key]
                [Column("SalesReasonID")]
                public int SalesReasonID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>bb729a72eaf9006c262eceb74e529c89</Hash>
</Codenesium>*/