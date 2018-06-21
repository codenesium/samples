using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiClaspRequestModel : AbstractApiRequestModel
        {
                public ApiClaspRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        int nextChainId,
                        int previousChainId)
                {
                        this.NextChainId = nextChainId;
                        this.PreviousChainId = previousChainId;
                }

                private int nextChainId;

                [Required]
                public int NextChainId
                {
                        get
                        {
                                return this.nextChainId;
                        }

                        set
                        {
                                this.nextChainId = value;
                        }
                }

                private int previousChainId;

                [Required]
                public int PreviousChainId
                {
                        get
                        {
                                return this.previousChainId;
                        }

                        set
                        {
                                this.previousChainId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>a1bcd4739f8a8cf0378495fe6e39281d</Hash>
</Codenesium>*/