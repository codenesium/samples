using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiPersonRequestModel: AbstractApiRequestModel
        {
                public ApiPersonRequestModel() : base()
                {
                }

                public void SetProperties(
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

                private string additionalContactInfo;

                public string AdditionalContactInfo
                {
                        get
                        {
                                return this.additionalContactInfo.IsEmptyOrZeroOrNull() ? null : this.additionalContactInfo;
                        }

                        set
                        {
                                this.additionalContactInfo = value;
                        }
                }

                private string demographics;

                public string Demographics
                {
                        get
                        {
                                return this.demographics.IsEmptyOrZeroOrNull() ? null : this.demographics;
                        }

                        set
                        {
                                this.demographics = value;
                        }
                }

                private int emailPromotion;

                [Required]
                public int EmailPromotion
                {
                        get
                        {
                                return this.emailPromotion;
                        }

                        set
                        {
                                this.emailPromotion = value;
                        }
                }

                private string firstName;

                [Required]
                public string FirstName
                {
                        get
                        {
                                return this.firstName;
                        }

                        set
                        {
                                this.firstName = value;
                        }
                }

                private string lastName;

                [Required]
                public string LastName
                {
                        get
                        {
                                return this.lastName;
                        }

                        set
                        {
                                this.lastName = value;
                        }
                }

                private string middleName;

                public string MiddleName
                {
                        get
                        {
                                return this.middleName.IsEmptyOrZeroOrNull() ? null : this.middleName;
                        }

                        set
                        {
                                this.middleName = value;
                        }
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private bool nameStyle;

                [Required]
                public bool NameStyle
                {
                        get
                        {
                                return this.nameStyle;
                        }

                        set
                        {
                                this.nameStyle = value;
                        }
                }

                private string personType;

                [Required]
                public string PersonType
                {
                        get
                        {
                                return this.personType;
                        }

                        set
                        {
                                this.personType = value;
                        }
                }

                private Guid rowguid;

                [Required]
                public Guid Rowguid
                {
                        get
                        {
                                return this.rowguid;
                        }

                        set
                        {
                                this.rowguid = value;
                        }
                }

                private string suffix;

                public string Suffix
                {
                        get
                        {
                                return this.suffix.IsEmptyOrZeroOrNull() ? null : this.suffix;
                        }

                        set
                        {
                                this.suffix = value;
                        }
                }

                private string title;

                public string Title
                {
                        get
                        {
                                return this.title.IsEmptyOrZeroOrNull() ? null : this.title;
                        }

                        set
                        {
                                this.title = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>796d469489a94060ec0ab82637ca2cb0</Hash>
</Codenesium>*/