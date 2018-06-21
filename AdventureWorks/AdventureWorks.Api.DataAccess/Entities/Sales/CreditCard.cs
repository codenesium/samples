using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("CreditCard", Schema="Sales")]
        public partial class CreditCard : AbstractEntity
        {
                public CreditCard()
                {
                }

                public void SetProperties(
                        string cardNumber,
                        string cardType,
                        int creditCardID,
                        int expMonth,
                        short expYear,
                        DateTime modifiedDate)
                {
                        this.CardNumber = cardNumber;
                        this.CardType = cardType;
                        this.CreditCardID = creditCardID;
                        this.ExpMonth = expMonth;
                        this.ExpYear = expYear;
                        this.ModifiedDate = modifiedDate;
                }

                [Column("CardNumber")]
                public string CardNumber { get; private set; }

                [Column("CardType")]
                public string CardType { get; private set; }

                [Key]
                [Column("CreditCardID")]
                public int CreditCardID { get; private set; }

                [Column("ExpMonth")]
                public int ExpMonth { get; private set; }

                [Column("ExpYear")]
                public short ExpYear { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2ff75c284aaf05666bd63c7b8effa994</Hash>
</Codenesium>*/