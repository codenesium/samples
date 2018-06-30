using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IBOLUsersMapper
        {
                BOUsers MapModelToBO(
                        int id,
                        ApiUsersRequestModel model);

                ApiUsersResponseModel MapBOToModel(
                        BOUsers boUsers);

                List<ApiUsersResponseModel> MapBOToModel(
                        List<BOUsers> items);
        }
}

/*<Codenesium>
    <Hash>2f4d0769d1b13ccd88a1dc04f6e269da</Hash>
</Codenesium>*/