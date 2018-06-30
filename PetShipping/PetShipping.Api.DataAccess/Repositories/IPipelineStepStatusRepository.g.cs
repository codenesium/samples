using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>8dcbc89f3bc3ac15b2a5504de5f7347d</Hash>
</Codenesium>*/