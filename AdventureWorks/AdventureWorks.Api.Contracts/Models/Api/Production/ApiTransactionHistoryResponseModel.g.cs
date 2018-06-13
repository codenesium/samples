using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiTransactionHistoryResponseModel: AbstractApiTransactionHistoryResponseModel
        {
                public ApiTransactionHistoryResponseModel()
                        : base()
                {
                }
        }
}

/*<Codenesium>
    <Hash>f5d9a3b561c3148528122b339879d857</Hash>
</Codenesium>*/