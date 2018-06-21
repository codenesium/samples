using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductModelIllustrationRequestModel : AbstractApiRequestModel
        {
                public ApiProductModelIllustrationRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        int illustrationID,
                        DateTime modifiedDate)
                {
                        this.IllustrationID = illustrationID;
                        this.ModifiedDate = modifiedDate;
                }

                private int illustrationID;

                [Required]
                public int IllustrationID
                {
                        get
                        {
                                return this.illustrationID;
                        }

                        set
                        {
                                this.illustrationID = value;
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
        }
}

/*<Codenesium>
    <Hash>8b94fc6d1e700684da6785f075e23867</Hash>
</Codenesium>*/