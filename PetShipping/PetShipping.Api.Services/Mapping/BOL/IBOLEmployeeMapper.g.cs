using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>ac100eb41aa17611652baf4380e6aef7</Hash>
</Codenesium>*/