using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>60375d334a688e43342fe2954340e2dd</Hash>
</Codenesium>*/