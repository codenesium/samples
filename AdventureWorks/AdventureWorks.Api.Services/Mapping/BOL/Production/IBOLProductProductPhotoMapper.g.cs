using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>1719b2fe32363b84b973cddfb7a01665</Hash>
</Codenesium>*/