using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IEmployeeService
        {
                Task<CreateResponse<ApiEmployeeResponseModel>> Create(
                        ApiEmployeeRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiEmployeeRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiEmployeeResponseModel> Get(int id);

                Task<List<ApiEmployeeResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiClientCommunicationResponseModel>> ClientCommunications(int employeeId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiPipelineStepResponseModel>> PipelineSteps(int shipperId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiPipelineStepNoteResponseModel>> PipelineStepNotes(int employeeId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>94b554d7c164c7b4f309aa17dbdcbca5</Hash>
</Codenesium>*/