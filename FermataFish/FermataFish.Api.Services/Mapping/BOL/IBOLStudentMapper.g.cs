using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>0e866c08a3a6beb20fc3dce33fd663ca</Hash>
</Codenesium>*/