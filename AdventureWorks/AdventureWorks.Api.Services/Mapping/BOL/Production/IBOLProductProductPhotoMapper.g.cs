using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLProductProductPhotoMapper
        {
                BOProductProductPhoto MapModelToBO(
                        int productID,
                        ApiProductProductPhotoRequestModel model);

                ApiProductProductPhotoResponseModel MapBOToModel(
                        BOProductProductPhoto boProductProductPhoto);

                List<ApiProductProductPhotoResponseModel> MapBOToModel(
                        List<BOProductProductPhoto> items);
        }
}

/*<Codenesium>
    <Hash>2b090682df9e1d2e27b8655a92c30e9d</Hash>
</Codenesium>*/