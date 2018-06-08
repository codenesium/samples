using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>3aafd99a297a4668c25968e833bab81a</Hash>
</Codenesium>*/