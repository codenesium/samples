using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Person", Schema="Person")]
        public partial class Person : AbstractEntity
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

                [Column("AdditionalContactInfo")]
                public string AdditionalContactInfo { get; private set; }

                [Key]
                [Column("BusinessEntityID")]
                public int BusinessEntityID { get; private set; }

                [Column("Demographics")]
                public string Demographics { get; private set; }

                [Column("EmailPromotion")]
                public int EmailPromotion { get; private set; }

                [Column("FirstName")]
                public string FirstName { get; private set; }

                [Column("LastName")]
                public string LastName { get; private set; }

                [Column("MiddleName")]
                public string MiddleName { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("NameStyle")]
                public bool NameStyle { get; private set; }

                [Column("PersonType")]
                public string PersonType { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Column("Suffix")]
                public string Suffix { get; private set; }

                [Column("Title")]
                public string Title { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a2e39adc41c62f933d158472a1b6cc5a</Hash>
</Codenesium>*/