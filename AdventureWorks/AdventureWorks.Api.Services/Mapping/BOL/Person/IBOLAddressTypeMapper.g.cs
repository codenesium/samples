using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLAddressTypeMapper
        {
                BOAddressType MapModelToBO(
                        int addressTypeID,
                        ApiAddressTypeRequestModel model);

                ApiAddressTypeResponseModel MapBOToModel(
                        BOAddressType boAddressType);

                List<ApiAddressTypeResponseModel> MapBOToModel(
                        List<BOAddressType> items);
        }
}

/*<Codenesium>
    <Hash>533affe40aad16ce5acc86c478c9457d</Hash>
</Codenesium>*/