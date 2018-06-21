using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>a7e8e39d0453c282fe53f84539dec7e9</Hash>
</Codenesium>*/