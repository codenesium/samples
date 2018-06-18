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

                Task<List<PipelineStepDestination>> All(int limit = int.MaxValue, int offset = 0);

                Task<Destination> GetDestination(int destinationId);
                Task<PipelineStep> GetPipelineStep(int pipelineStepId);
        }
}

/*<Codenesium>
    <Hash>29463c86b7e314258cf5a38b4e887624</Hash>
</Codenesium>*/