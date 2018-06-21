using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>6b33efa35b5e2bd1f51db8befda5fb6e</Hash>
</Codenesium>*/