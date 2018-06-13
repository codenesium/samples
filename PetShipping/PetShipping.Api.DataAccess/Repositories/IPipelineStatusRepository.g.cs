using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IPipelineStatusRepository
        {
                Task<PipelineStatus> Create(PipelineStatus item);

                Task Update(PipelineStatus item);

                Task Delete(int id);

                Task<PipelineStatus> Get(int id);

                Task<List<PipelineStatus>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Pipeline>> Pipelines(int pipelineStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d4f22b18e58e859ddc723d18a6b8ff13</Hash>
</Codenesium>*/