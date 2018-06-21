using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>830eb1946ef681ccbe8d87cbad2dac8b</Hash>
</Codenesium>*/