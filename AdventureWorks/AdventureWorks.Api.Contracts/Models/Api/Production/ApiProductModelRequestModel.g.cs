using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductModelRequestModel : AbstractApiRequestModel
        {
                public ApiProductModelRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        string catalogDescription,
                        string instructions,
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid)
                {
                        this.CatalogDescription = catalogDescription;
                        this.Instructions = instructions;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                }

                private string catalogDescription;

                public string CatalogDescription
                {
                        get
                        {
                                return this.catalogDescription.IsEmptyOrZeroOrNull() ? null : this.catalogDescription;
                        }

                        set
                        {
                                this.catalogDescription = value;
                        }
                }

                private string instructions;

                public string Instructions
                {
                        get
                        {
                                return this.instructions.IsEmptyOrZeroOrNull() ? null : this.instructions;
                        }

                        set
                        {
                                this.instructions = value;
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
        }
}

/*<Codenesium>
    <Hash>bc3ebc00141d46cc057e7277dea382fd</Hash>
</Codenesium>*/