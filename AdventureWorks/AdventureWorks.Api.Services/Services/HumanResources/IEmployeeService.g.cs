using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IEmployeeService
        {
                Task<CreateResponse<ApiEmployeeResponseModel>> Create(
                        ApiEmployeeRequestModel model);

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiEmployeeRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiEmployeeResponseModel> Get(int businessEntityID);

                Task<List<ApiEmployeeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiEmployeeResponseModel> GetLoginID(string loginID);
                Task<ApiEmployeeResponseModel> GetNationalIDNumber(string nationalIDNumber);
                Task<List<ApiEmployeeResponseModel>> GetOrganizationLevelOrganizationNode(Nullable<short> organizationLevel, Nullable<Guid> organizationNode);
                Task<List<ApiEmployeeResponseModel>> GetOrganizationNode(Nullable<Guid> organizationNode);
        }
}

/*<Codenesium>
    <Hash>40ddc3e8fd527f160bfd7758f714351a</Hash>
</Codenesium>*/