using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("CurrencyRate", Schema="Sales")]
        public partial class CurrencyRate: AbstractEntity
        {
                public CurrencyRate()
                {
                }

                public void SetProperties(
                        decimal averageRate,
                        DateTime currencyRateDate,
                        int currencyRateID,
                        decimal endOfDayRate,
                        string fromCurrencyCode,
                        DateTime modifiedDate,
                        string toCurrencyCode)
                {
                        this.AverageRate = averageRate;
                        this.CurrencyRateDate = currencyRateDate;
                        this.CurrencyRateID = currencyRateID;
                        this.EndOfDayRate = endOfDayRate;
                        this.FromCurrencyCode = fromCurrencyCode;
                        this.ModifiedDate = modifiedDate;
                        this.ToCurrencyCode = toCurrencyCode;
                }

                [Column("AverageRate", TypeName="money")]
                public decimal AverageRate { get; private set; }

                [Column("CurrencyRateDate", TypeName="datetime")]
                public DateTime CurrencyRateDate { get; private set; }

                [Key]
                [Column("CurrencyRateID", TypeName="int")]
                public int CurrencyRateID { get; private set; }

                [Column("EndOfDayRate", TypeName="money")]
                public decimal EndOfDayRate { get; private set; }

                [Column("FromCurrencyCode", TypeName="nchar(3)")]
                public string FromCurrencyCode { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("ToCurrencyCode", TypeName="nchar(3)")]
                public string ToCurrencyCode { get; private set; }

                [ForeignKey("FromCurrencyCode")]
                public virtual Currency Currency { get; set; }

                [ForeignKey("ToCurrencyCode")]
                public virtual Currency Currency1 { get; set; }
        }
}

/*<Codenesium>
    <Hash>6abc13cd7b610ec0eec01f477399eddd</Hash>
</Codenesium>*/