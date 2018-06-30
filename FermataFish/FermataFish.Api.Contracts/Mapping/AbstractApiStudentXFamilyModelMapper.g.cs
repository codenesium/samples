using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiStudentXFamilyModelMapper
        {
                public virtual ApiStudentXFamilyResponseModel MapRequestToResponse(
                        int id,
                        ApiStudentXFamilyRequestModel request)
                {
                        var response = new ApiStudentXFamilyResponseModel();
                        response.SetProperties(id,
                                               request.FamilyId,
                                               request.StudentId);
                        return response;
                }

                public virtual ApiStudentXFamilyRequestModel MapResponseToRequest(
                        ApiStudentXFamilyResponseModel response)
                {
                        var request = new ApiStudentXFamilyRequestModel();
                        request.SetProperties(
                                response.FamilyId,
                                response.StudentId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>1c5d180c10c8539d7694b621c79ae173</Hash>
</Codenesium>*/