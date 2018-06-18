using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IHandlerPipelineStepRepository
        {
                Task<HandlerPipelineStep> Create(HandlerPipelineStep item);

                Task Update(HandlerPipelineStep item);

                Task Delete(int id);

                Task<HandlerPipelineStep> Get(int id);

                Task<List<HandlerPipelineStep>> All(int limit = int.MaxValue, int offset = 0);

                Task<Handler> GetHandler(int handlerId);
                Task<PipelineStep> GetPipelineStep(int pipelineStepId);
        }
}

/*<Codenesium>
    <Hash>8ab98866baa4ef26f7601d907ee19dcf</Hash>
</Codenesium>*/