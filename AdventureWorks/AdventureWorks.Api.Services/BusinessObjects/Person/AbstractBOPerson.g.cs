using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOPerson: AbstractBusinessObject
        {
                public AbstractBOPerson() : base()
                {
                }

                public virtual void SetProperties(int businessEntityID,
                                                  string additionalContactInfo,
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

                public string AdditionalContactInfo { get; private set; }

                public int BusinessEntityID { get; private set; }

                public string Demographics { get; private set; }

                public int EmailPromotion { get; private set; }

                public string FirstName { get; private set; }

                public string LastName { get; private set; }

                public string MiddleName { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public bool NameStyle { get; private set; }

                public string PersonType { get; private set; }

                public Guid Rowguid { get; private set; }

                public string Suffix { get; private set; }

                public string Title { get; private set; }
        }
}

/*<Codenesium>
    <Hash>04565a0a074971e0a6e7bb7f20b59ce8</Hash>
</Codenesium>*/