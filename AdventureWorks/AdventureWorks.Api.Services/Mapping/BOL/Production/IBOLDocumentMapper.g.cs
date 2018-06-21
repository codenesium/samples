using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>bad092fc46695c6529800410b724aea3</Hash>
</Codenesium>*/