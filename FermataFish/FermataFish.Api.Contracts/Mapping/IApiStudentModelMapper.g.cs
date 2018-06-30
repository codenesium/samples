using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public interface IApiStudentModelMapper
        {
                ApiStudentResponseModel MapRequestToResponse(
                        int id,
                        ApiStudentRequestModel request);

                ApiStudentRequestModel MapResponseToRequest(
                        ApiStudentResponseModel response);
        }
}

/*<Codenesium>
    <Hash>27c38c5b709e1fcedfa1b5ffcfb71e02</Hash>
</Codenesium>*/