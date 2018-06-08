using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("PersonCreditCard", Schema="Sales")]
        public partial class PersonCreditCard: AbstractEntity
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
                [Column("BusinessEntityID", TypeName="int")]
                public int BusinessEntityID { get; private set; }

                [Column("CreditCardID", TypeName="int")]
                public int CreditCardID { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [ForeignKey("CreditCardID")]
                public virtual CreditCard CreditCard { get; set; }
        }
}

/*<Codenesium>
    <Hash>82c852544e64d0acd72bddfbbf159358</Hash>
</Codenesium>*/