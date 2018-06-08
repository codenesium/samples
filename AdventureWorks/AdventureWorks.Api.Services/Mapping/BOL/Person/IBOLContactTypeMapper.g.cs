using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLContactTypeMapper
        {
                BOContactType MapModelToBO(
                        int contactTypeID,
                        ApiContactTypeRequestModel model);

                ApiContactTypeResponseModel MapBOToModel(
                        BOContactType boContactType);

                List<ApiContactTypeResponseModel> MapBOToModel(
                        List<BOContactType> items);
        }
}

/*<Codenesium>
    <Hash>29e5a9dbfc8ab8739c80b64c58626f9e</Hash>
</Codenesium>*/