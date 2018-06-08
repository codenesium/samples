using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLDocumentMapper
        {
                BODocument MapModelToBO(
                        Guid documentNode,
                        ApiDocumentRequestModel model);

                ApiDocumentResponseModel MapBOToModel(
                        BODocument boDocument);

                List<ApiDocumentResponseModel> MapBOToModel(
                        List<BODocument> items);
        }
}

/*<Codenesium>
    <Hash>eb171f4422355c72e5d6946cdf928e67</Hash>
</Codenesium>*/