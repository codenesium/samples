using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductProductPhotoRequestModel : AbstractApiRequestModel
        {
                public ApiProductProductPhotoRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        bool primary,
                        int productPhotoID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Primary = primary;
                        this.ProductPhotoID = productPhotoID;
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

                private bool primary;

                [Required]
                public bool Primary
                {
                        get
                        {
                                return this.primary;
                        }

                        set
                        {
                                this.primary = value;
                        }
                }

                private int productPhotoID;

                [Required]
                public int ProductPhotoID
                {
                        get
                        {
                                return this.productPhotoID;
                        }

                        set
                        {
                                this.productPhotoID = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>0763a2852eb028ed6c3e5c4f891873a2</Hash>
</Codenesium>*/