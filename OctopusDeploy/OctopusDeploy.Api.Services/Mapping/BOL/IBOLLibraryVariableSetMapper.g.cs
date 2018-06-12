using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IBOLLibraryVariableSetMapper
        {
                BOLibraryVariableSet MapModelToBO(
                        string id,
                        ApiLibraryVariableSetRequestModel model);

                ApiLibraryVariableSetResponseModel MapBOToModel(
                        BOLibraryVariableSet boLibraryVariableSet);

                List<ApiLibraryVariableSetResponseModel> MapBOToModel(
                        List<BOLibraryVariableSet> items);
        }
}

/*<Codenesium>
    <Hash>1c859e436a88753f9edaba50793f4773</Hash>
</Codenesium>*/