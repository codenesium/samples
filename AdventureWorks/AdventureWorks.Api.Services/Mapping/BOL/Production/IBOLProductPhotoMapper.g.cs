using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLProductPhotoMapper
        {
                BOProductPhoto MapModelToBO(
                        int productPhotoID,
                        ApiProductPhotoRequestModel model);

                ApiProductPhotoResponseModel MapBOToModel(
                        BOProductPhoto boProductPhoto);

                List<ApiProductPhotoResponseModel> MapBOToModel(
                        List<BOProductPhoto> items);
        }
}

/*<Codenesium>
    <Hash>b3fbdabd9ed92cdab97beb62fc477bc0</Hash>
</Codenesium>*/