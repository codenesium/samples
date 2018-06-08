using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IBOLEmployeeMapper
        {
                BOEmployee MapModelToBO(
                        int id,
                        ApiEmployeeRequestModel model);

                ApiEmployeeResponseModel MapBOToModel(
                        BOEmployee boEmployee);

                List<ApiEmployeeResponseModel> MapBOToModel(
                        List<BOEmployee> items);
        }
}

/*<Codenesium>
    <Hash>715046bb5221421ca7be9f5040ba9bf5</Hash>
</Codenesium>*/