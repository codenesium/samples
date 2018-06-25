using Codenesium.DataConversionExtensions;
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
    <Hash>2ae84a731a736081748f9e9601782e21</Hash>
</Codenesium>*/