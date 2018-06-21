using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("EmployeePayHistory", Schema="HumanResources")]
        public partial class EmployeePayHistory : AbstractEntity
        {
                public EmployeePayHistory()
                {
                }

                public void SetProperties(
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
    <Hash>8c8cead4257a433cd9d96ad9febf165b</Hash>
</Codenesium>*/