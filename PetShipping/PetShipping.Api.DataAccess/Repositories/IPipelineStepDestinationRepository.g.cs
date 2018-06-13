using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IPipelineStepDestinationRepository
        {
                Task<PipelineStepDestination> Create(PipelineStepDestination item);

                Task Update(PipelineStepDestination item);

                Task Delete(int id);

                Task<PipelineStepDestination> Get(int id);

                Task<List<PipelineStepDestination>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>9ce798e2d7c0953b9813fca40ec702fd</Hash>
</Codenesium>*/