using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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

                public virtual void SetProperties(
                        string demographics,
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid,
                        int? salesPersonID)
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
                                return this.demographics;
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

                private int? salesPersonID;

                public int? SalesPersonID
                {
                        get
                        {
                                return this.salesPersonID;
                        }

                        set
                        {
                                this.salesPersonID = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>95fd98fe654f004b6377d4b5a9089f48</Hash>
</Codenesium>*/