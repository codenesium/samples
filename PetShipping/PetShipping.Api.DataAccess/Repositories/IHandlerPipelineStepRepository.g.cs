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

                Task<List<HandlerPipelineStep>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>e411d5445ed6984ac93fc8366247e4d4</Hash>
</Codenesium>*/