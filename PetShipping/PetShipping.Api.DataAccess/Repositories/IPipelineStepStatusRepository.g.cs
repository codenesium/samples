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

                Task<List<PipelineStepStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>31a09e65705127aa964594fcdb305d41</Hash>
</Codenesium>*/