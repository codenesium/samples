using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLStateProvinceMapper
        {
                BOStateProvince MapModelToBO(
                        int stateProvinceID,
                        ApiStateProvinceRequestModel model);

                ApiStateProvinceResponseModel MapBOToModel(
                        BOStateProvince boStateProvince);

                List<ApiStateProvinceResponseModel> MapBOToModel(
                        List<BOStateProvince> items);
        }
}

/*<Codenesium>
    <Hash>a9a75e50307c79350a44780ffd0b37ca</Hash>
</Codenesium>*/