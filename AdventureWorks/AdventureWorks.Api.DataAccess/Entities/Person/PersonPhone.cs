using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("PersonPhone", Schema="Person")]
        public partial class PersonPhone : AbstractEntity
        {
                public PersonPhone()
                {
                }

                public void SetProperties(
                        int businessEntityID,
                        DateTime modifiedDate,
                        string phoneNumber,
                        int phoneNumberTypeID)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.PhoneNumber = phoneNumber;
                        this.PhoneNumberTypeID = phoneNumberTypeID;
                }

                [Key]
                [Column("BusinessEntityID")]
                public int BusinessEntityID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("PhoneNumber")]
                public string PhoneNumber { get; private set; }

                [Column("PhoneNumberTypeID")]
                public int PhoneNumberTypeID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>61454c8008b5d8d4b579ed033278c603</Hash>
</Codenesium>*/