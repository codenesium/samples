using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLProductDescriptionMapper
        {
                BOProductDescription MapModelToBO(
                        int productDescriptionID,
                        ApiProductDescriptionRequestModel model);

                ApiProductDescriptionResponseModel MapBOToModel(
                        BOProductDescription boProductDescription);

                List<ApiProductDescriptionResponseModel> MapBOToModel(
                        List<BOProductDescription> items);
        }
}

/*<Codenesium>
    <Hash>29a096e4d9a2fbf885700e184dabdf28</Hash>
</Codenesium>*/