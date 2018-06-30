using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductDescriptionRequestModel : AbstractApiRequestModel
        {
                public ApiProductDescriptionRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string description,
                        DateTime modifiedDate,
                        Guid rowguid)
                {
                        this.Description = description;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                }

                private string description;

                [Required]
                public string Description
                {
                        get
                        {
                                return this.description;
                        }

                        set
                        {
                                this.description = value;
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
    <Hash>2b5a05d965ad04e643c81e863b9f0bb5</Hash>
</Codenesium>*/