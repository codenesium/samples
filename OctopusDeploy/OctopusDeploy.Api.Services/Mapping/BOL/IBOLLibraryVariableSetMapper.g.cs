using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>12fda21fd6856e70fab66f5fdadef4a2</Hash>
</Codenesium>*/