using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLDocumentMapper
        {
                BODocument MapModelToBO(
                        Guid rowguid,
                        ApiDocumentRequestModel model);

                ApiDocumentResponseModel MapBOToModel(
                        BODocument boDocument);

                List<ApiDocumentResponseModel> MapBOToModel(
                        List<BODocument> items);
        }
}

/*<Codenesium>
    <Hash>c7a3e910cfeda263442beb5f50ab17fb</Hash>
</Codenesium>*/