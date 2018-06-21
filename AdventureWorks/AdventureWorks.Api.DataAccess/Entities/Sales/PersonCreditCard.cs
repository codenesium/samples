using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("PersonCreditCard", Schema="Sales")]
        public partial class PersonCreditCard : AbstractEntity
        {
                public PersonCreditCard()
                {
                }

                public void SetProperties(
                        int businessEntityID,
                        int creditCardID,
                        DateTime modifiedDate)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.CreditCardID = creditCardID;
                        this.ModifiedDate = modifiedDate;
                }

                [Key]
                [Column("BusinessEntityID")]
                public int BusinessEntityID { get; private set; }

                [Column("CreditCardID")]
                public int CreditCardID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [ForeignKey("CreditCardID")]
                public virtual CreditCard CreditCard { get; set; }
        }
}

/*<Codenesium>
    <Hash>98854ef3d8f41c0acfe57d0b97b13724</Hash>
</Codenesium>*/