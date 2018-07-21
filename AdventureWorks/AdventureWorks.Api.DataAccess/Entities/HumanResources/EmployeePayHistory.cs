using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("EmployeePayHistory", Schema="HumanResources")]
        public partial class EmployeePayHistory : AbstractEntity
        {
                public EmployeePayHistory()
                {
                }

                public virtual void SetProperties(
                        int businessEntityID,
                        DateTime modifiedDate,
                        int payFrequency,
                        decimal rate,
                        DateTime rateChangeDate)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.PayFrequency = payFrequency;
                        this.Rate = rate;
                        this.RateChangeDate = rateChangeDate;
                }

                [Key]
                [Column("BusinessEntityID")]
                public int BusinessEntityID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("PayFrequency")]
                public int PayFrequency { get; private set; }

                [Column("Rate")]
                public decimal Rate { get; private set; }

                [Column("RateChangeDate")]
                public DateTime RateChangeDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>126f1ea7621e360c7515e17bef800ee0</Hash>
</Codenesium>*/