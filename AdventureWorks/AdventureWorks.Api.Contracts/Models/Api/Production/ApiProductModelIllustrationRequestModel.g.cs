using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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

                public virtual void SetProperties(
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
    <Hash>34bc5acd30311aad81a99b8bedb055cb</Hash>
</Codenesium>*/