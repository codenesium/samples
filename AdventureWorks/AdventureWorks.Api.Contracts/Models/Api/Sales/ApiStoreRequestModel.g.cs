using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiStoreRequestModel : AbstractApiRequestModel
        {
                public ApiStoreRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        string demographics,
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid,
                        Nullable<int> salesPersonID)
                {
                        this.Demographics = demographics;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                        this.SalesPersonID = salesPersonID;
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

                private Nullable<int> salesPersonID;

                public Nullable<int> SalesPersonID
                {
                        get
                        {
                                return this.salesPersonID.IsEmptyOrZeroOrNull() ? null : this.salesPersonID;
                        }

                        set
                        {
                                this.salesPersonID = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>b9f3f5f65d4931af1b3add9859b2ad7e</Hash>
</Codenesium>*/