using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>6187c859e7dded2e6538693b3ae789e9</Hash>
</Codenesium>*/