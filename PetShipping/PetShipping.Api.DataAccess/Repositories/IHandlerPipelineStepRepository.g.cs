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

                Task<List<HandlerPipelineStep>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>f47d0a585453e41c6556619394a508c2</Hash>
</Codenesium>*/