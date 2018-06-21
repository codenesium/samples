using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLProductModelMapper
        {
                BOProductModel MapModelToBO(
                        int productModelID,
                        ApiProductModelRequestModel model);

                ApiProductModelResponseModel MapBOToModel(
                        BOProductModel boProductModel);

                List<ApiProductModelResponseModel> MapBOToModel(
                        List<BOProductModel> items);
        }
}

/*<Codenesium>
    <Hash>f101dfccd3bdc732bb98cf8be91b5d29</Hash>
</Codenesium>*/