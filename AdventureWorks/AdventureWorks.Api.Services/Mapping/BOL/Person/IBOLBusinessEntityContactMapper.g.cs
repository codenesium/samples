using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLBusinessEntityContactMapper
        {
                BOBusinessEntityContact MapModelToBO(
                        int businessEntityID,
                        ApiBusinessEntityContactRequestModel model);

                ApiBusinessEntityContactResponseModel MapBOToModel(
                        BOBusinessEntityContact boBusinessEntityContact);

                List<ApiBusinessEntityContactResponseModel> MapBOToModel(
                        List<BOBusinessEntityContact> items);
        }
}

/*<Codenesium>
    <Hash>e2a23556e8d74209cdc6e90ba14b1b8a</Hash>
</Codenesium>*/