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

                Task<List<PipelineStatus>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Pipeline>> Pipelines(int pipelineStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>37adef6c0e1afb90b6e0942545946485</Hash>
</Codenesium>*/