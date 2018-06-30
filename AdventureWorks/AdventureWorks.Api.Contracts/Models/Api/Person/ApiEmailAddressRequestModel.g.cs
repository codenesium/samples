using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiEmailAddressRequestModel : AbstractApiRequestModel
        {
                public ApiEmailAddressRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string emailAddress1,
                        int emailAddressID,
                        DateTime modifiedDate,
                        Guid rowguid)
                {
                        this.EmailAddress1 = emailAddress1;
                        this.EmailAddressID = emailAddressID;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                }

                private string emailAddress1;

                public string EmailAddress1
                {
                        get
                        {
                                return this.emailAddress1;
                        }

                        set
                        {
                                this.emailAddress1 = value;
                        }
                }

                private int emailAddressID;

                [Required]
                public int EmailAddressID
                {
                        get
                        {
                                return this.emailAddressID;
                        }

                        set
                        {
                                this.emailAddressID = value;
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
        }
}

/*<Codenesium>
    <Hash>793e78ccf41320ac6aa1c69a08d76788</Hash>
</Codenesium>*/