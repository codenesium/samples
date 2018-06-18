using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IOtherTransportRepository
        {
                Task<OtherTransport> Create(OtherTransport item);

                Task Update(OtherTransport item);

                Task Delete(int id);

                Task<OtherTransport> Get(int id);

                Task<List<OtherTransport>> All(int limit = int.MaxValue, int offset = 0);

                Task<Handler> GetHandler(int handlerId);
                Task<PipelineStep> GetPipelineStep(int pipelineStepId);
        }
}

/*<Codenesium>
    <Hash>d3ae7b50d976afdd02726e9b7e618aef</Hash>
</Codenesium>*/