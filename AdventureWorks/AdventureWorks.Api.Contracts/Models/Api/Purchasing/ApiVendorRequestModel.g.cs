using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiVendorRequestModel: AbstractApiRequestModel
        {
                public ApiVendorRequestModel() : base()
                {
                }

                public void SetProperties(
                        string accountNumber,
                        bool activeFlag,
                        int creditRating,
                        DateTime modifiedDate,
                        string name,
                        bool preferredVendorStatus,
                        string purchasingWebServiceURL)
                {
                        this.AccountNumber = accountNumber;
                        this.ActiveFlag = activeFlag;
                        this.CreditRating = creditRating;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.PreferredVendorStatus = preferredVendorStatus;
                        this.PurchasingWebServiceURL = purchasingWebServiceURL;
                }

                private string accountNumber;

                [Required]
                public string AccountNumber
                {
                        get
                        {
                                return this.accountNumber;
                        }

                        set
                        {
                                this.accountNumber = value;
                        }
                }

                private bool activeFlag;

                [Required]
                public bool ActiveFlag
                {
                        get
                        {
                                return this.activeFlag;
                        }

                        set
                        {
                                this.activeFlag = value;
                        }
                }

                private int creditRating;

                [Required]
                public int CreditRating
                {
                        get
                        {
                                return this.creditRating;
                        }

                        set
                        {
                                this.creditRating = value;
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

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }

                private bool preferredVendorStatus;

                [Required]
                public bool PreferredVendorStatus
                {
                        get
                        {
                                return this.preferredVendorStatus;
                        }

                        set
                        {
                                this.preferredVendorStatus = value;
                        }
                }

                private string purchasingWebServiceURL;

                public string PurchasingWebServiceURL
                {
                        get
                        {
                                return this.purchasingWebServiceURL.IsEmptyOrZeroOrNull() ? null : this.purchasingWebServiceURL;
                        }

                        set
                        {
                                this.purchasingWebServiceURL = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>0ffbd330f26b879af1ca4c3850bac0da</Hash>
</Codenesium>*/