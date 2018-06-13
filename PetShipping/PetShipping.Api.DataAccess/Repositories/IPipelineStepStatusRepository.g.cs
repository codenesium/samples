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

                Task<List<PipelineStepStatus>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<PipelineStep>> PipelineSteps(int pipelineStepStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>da4595218b51faa82a19f0ae7d9f2487</Hash>
</Codenesium>*/