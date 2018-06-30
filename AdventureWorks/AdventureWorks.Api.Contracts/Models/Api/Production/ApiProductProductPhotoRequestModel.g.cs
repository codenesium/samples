using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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

                public virtual void SetProperties(
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
    <Hash>55527d4f9d3f4736a11bacb3846d87d8</Hash>
</Codenesium>*/