using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductModelProductDescriptionCultureRequestModel : AbstractApiRequestModel
        {
                public ApiProductModelProductDescriptionCultureRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        string cultureID,
                        DateTime modifiedDate,
                        int productDescriptionID)
                {
                        this.CultureID = cultureID;
                        this.ModifiedDate = modifiedDate;
                        this.ProductDescriptionID = productDescriptionID;
                }

                private string cultureID;

                [Required]
                public string CultureID
                {
                        get
                        {
                                return this.cultureID;
                        }

                        set
                        {
                                this.cultureID = value;
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

                private int productDescriptionID;

                [Required]
                public int ProductDescriptionID
                {
                        get
                        {
                                return this.productDescriptionID;
                        }

                        set
                        {
                                this.productDescriptionID = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>4d8e86f2c17e192f632c832f7944a653</Hash>
</Codenesium>*/