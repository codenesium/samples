using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Currency", Schema="Sales")]
        public partial class Currency: AbstractEntity
        {
                public Currency()
                {
                }

                public void SetProperties(
                        string currencyCode,
                        DateTime modifiedDate,
                        string name)
                {
                        this.CurrencyCode = currencyCode;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                [Key]
                [Column("CurrencyCode", TypeName="nchar(3)")]
                public string CurrencyCode { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name", TypeName="nvarchar(50)")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>eb0e45a92265a9beb273141ebfdb0cdb</Hash>
</Codenesium>*/