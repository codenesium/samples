using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>9046ca27f7b1ef316bc144c4403143f7</Hash>
</Codenesium>*/