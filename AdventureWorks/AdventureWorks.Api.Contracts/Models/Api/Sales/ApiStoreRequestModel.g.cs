using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiStoreRequestModel: AbstractApiRequestModel
        {
                public ApiStoreRequestModel() : base()
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
    <Hash>38e18c87be63808c8f2b5be4a9c4cde0</Hash>
</Codenesium>*/