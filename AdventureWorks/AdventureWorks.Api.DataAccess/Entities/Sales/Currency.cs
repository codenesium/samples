using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Currency", Schema="Sales")]
        public partial class Currency : AbstractEntity
        {
                public Currency()
                {
                }

                public virtual void SetProperties(
                        string currencyCode,
                        DateTime modifiedDate,
                        string name)
                {
                        this.CurrencyCode = currencyCode;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                [Key]
                [Column("CurrencyCode")]
                public string CurrencyCode { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9344726c226f04fba40ea0d51f1b0dfd</Hash>
</Codenesium>*/