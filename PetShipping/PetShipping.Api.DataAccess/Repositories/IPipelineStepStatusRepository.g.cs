using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IPipelineStepStatusRepository
        {
                Task<PipelineStepStatus> Create(PipelineStepStatus item);

                Task Update(PipelineStepStatus item);

                Task Delete(int id);

                Task<PipelineStepStatus> Get(int id);

                Task<List<PipelineStepStatus>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<PipelineStep>> PipelineSteps(int pipelineStepStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>c55eaa52a5bac4f6db0e6463e1e27a72</Hash>
</Codenesium>*/