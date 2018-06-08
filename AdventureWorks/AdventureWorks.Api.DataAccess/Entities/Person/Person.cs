using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Person", Schema="Person")]
        public partial class Person:AbstractEntity
        {
                public Person()
                {
                }

                public void SetProperties(
                        string additionalContactInfo,
                        int businessEntityID,
                        string demographics,
                        int emailPromotion,
                        string firstName,
                        string lastName,
                        string middleName,
                        DateTime modifiedDate,
                        bool nameStyle,
                        string personType,
                        Guid rowguid,
                        string suffix,
                        string title)
                {
                        this.AdditionalContactInfo = additionalContactInfo;
                        this.BusinessEntityID = businessEntityID;
                        this.Demographics = demographics;
                        this.EmailPromotion = emailPromotion;
                        this.FirstName = firstName;
                        this.LastName = lastName;
                        this.MiddleName = middleName;
                        this.ModifiedDate = modifiedDate;
                        this.NameStyle = nameStyle;
                        this.PersonType = personType;
                        this.Rowguid = rowguid;
                        this.Suffix = suffix;
                        this.Title = title;
                }

                [Column("AdditionalContactInfo", TypeName="xml(-1)")]
                public string AdditionalContactInfo { get; private set; }

                [Key]
                [Column("BusinessEntityID", TypeName="int")]
                public int BusinessEntityID { get; private set; }

                [Column("Demographics", TypeName="xml(-1)")]
                public string Demographics { get; private set; }

                [Column("EmailPromotion", TypeName="int")]
                public int EmailPromotion { get; private set; }

                [Column("FirstName", TypeName="nvarchar(50)")]
                public string FirstName { get; private set; }

                [Column("LastName", TypeName="nvarchar(50)")]
                public string LastName { get; private set; }

                [Column("MiddleName", TypeName="nvarchar(50)")]
                public string MiddleName { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("NameStyle", TypeName="bit")]
                public bool NameStyle { get; private set; }

                [Column("PersonType", TypeName="nchar(2)")]
                public string PersonType { get; private set; }

                [Column("rowguid", TypeName="uniqueidentifier")]
                public Guid Rowguid { get; private set; }

                [Column("Suffix", TypeName="nvarchar(10)")]
                public string Suffix { get; private set; }

                [Column("Title", TypeName="nvarchar(8)")]
                public string Title { get; private set; }
        }
}

/*<Codenesium>
    <Hash>021249528cc4e56fbe5b1bbbbd7449be</Hash>
</Codenesium>*/