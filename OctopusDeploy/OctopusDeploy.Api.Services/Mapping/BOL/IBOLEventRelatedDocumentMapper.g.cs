using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLEventRelatedDocumentMapper
        {
                BOEventRelatedDocument MapModelToBO(
                        int id,
                        ApiEventRelatedDocumentRequestModel model);

                ApiEventRelatedDocumentResponseModel MapBOToModel(
                        BOEventRelatedDocument boEventRelatedDocument);

                List<ApiEventRelatedDocumentResponseModel> MapBOToModel(
                        List<BOEventRelatedDocument> items);
        }
}

/*<Codenesium>
    <Hash>8e7acd1a4cad5d5dffaef91dd9fbbe68</Hash>
</Codenesium>*/