using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>64e0e83b80673dbd789fb317763293e1</Hash>
</Codenesium>*/