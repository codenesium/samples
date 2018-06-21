using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLTagSetMapper
        {
                BOTagSet MapModelToBO(
                        string id,
                        ApiTagSetRequestModel model);

                ApiTagSetResponseModel MapBOToModel(
                        BOTagSet boTagSet);

                List<ApiTagSetResponseModel> MapBOToModel(
                        List<BOTagSet> items);
        }
}

/*<Codenesium>
    <Hash>3c39b855704c1eeaaecaee75893601ae</Hash>
</Codenesium>*/