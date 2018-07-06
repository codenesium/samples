using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiPersonResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int businessEntityID,
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
                        this.BusinessEntityID = businessEntityID;
                        this.AdditionalContactInfo = additionalContactInfo;
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
    <Hash>1295153e1a0c73c7f59c34dddb8eb684</Hash>
</Codenesium>*/