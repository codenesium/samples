using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLPhoneNumberTypeMapper
        {
                BOPhoneNumberType MapModelToBO(
                        int phoneNumberTypeID,
                        ApiPhoneNumberTypeRequestModel model);

                ApiPhoneNumberTypeResponseModel MapBOToModel(
                        BOPhoneNumberType boPhoneNumberType);

                List<ApiPhoneNumberTypeResponseModel> MapBOToModel(
                        List<BOPhoneNumberType> items);
        }
}

/*<Codenesium>
    <Hash>f1a614a90b2105651fa116c392303c4b</Hash>
</Codenesium>*/