using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IPipelineRepository
        {
                Task<Pipeline> Create(Pipeline item);

                Task Update(Pipeline item);

                Task Delete(int id);

                Task<Pipeline> Get(int id);

                Task<List<Pipeline>> All(int limit = int.MaxValue, int offset = 0);

                Task<PipelineStatus> GetPipelineStatus(int pipelineStatusId);
        }
}

/*<Codenesium>
    <Hash>f9c538b6f090fdcce2e42218c7c3cb64</Hash>
</Codenesium>*/