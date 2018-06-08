using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLProductDocumentMapper
        {
                BOProductDocument MapModelToBO(
                        int productID,
                        ApiProductDocumentRequestModel model);

                ApiProductDocumentResponseModel MapBOToModel(
                        BOProductDocument boProductDocument);

                List<ApiProductDocumentResponseModel> MapBOToModel(
                        List<BOProductDocument> items);
        }
}

/*<Codenesium>
    <Hash>70892c3286a695b2117598b901b5d322</Hash>
</Codenesium>*/