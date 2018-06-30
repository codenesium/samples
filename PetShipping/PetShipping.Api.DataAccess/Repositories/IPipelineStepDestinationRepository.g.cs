using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IPipelineStepDestinationRepository
        {
                Task<PipelineStepDestination> Create(PipelineStepDestination item);

                Task Update(PipelineStepDestination item);

                Task Delete(int id);

                Task<PipelineStepDestination> Get(int id);

                Task<List<PipelineStepDestination>> All(int limit = int.MaxValue, int offset = 0);

                Task<Destination> GetDestination(int destinationId);

                Task<PipelineStep> GetPipelineStep(int pipelineStepId);
        }
}

/*<Codenesium>
    <Hash>661d784ad1f6d56f7f1ac25dbc50575e</Hash>
</Codenesium>*/