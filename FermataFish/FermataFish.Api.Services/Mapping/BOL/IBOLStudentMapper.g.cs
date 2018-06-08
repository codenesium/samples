using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IBOLStudentMapper
        {
                BOStudent MapModelToBO(
                        int id,
                        ApiStudentRequestModel model);

                ApiStudentResponseModel MapBOToModel(
                        BOStudent boStudent);

                List<ApiStudentResponseModel> MapBOToModel(
                        List<BOStudent> items);
        }
}

/*<Codenesium>
    <Hash>0a1c662935a1321d757c7c4a837b7e5c</Hash>
</Codenesium>*/