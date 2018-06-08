using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IPipelineStepRepository
        {
                Task<PipelineStep> Create(PipelineStep item);

                Task Update(PipelineStep item);

                Task Delete(int id);

                Task<PipelineStep> Get(int id);

                Task<List<PipelineStep>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>a08f8f56972b2a03a6c462b4d2fc9183</Hash>
</Codenesium>*/