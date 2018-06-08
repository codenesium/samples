using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>5d1a035eabc04a0fb5ec469ca358c7c2</Hash>
</Codenesium>*/