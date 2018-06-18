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

                Task<List<PipelineStep>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<HandlerPipelineStep>> HandlerPipelineSteps(int pipelineStepId, int limit = int.MaxValue, int offset = 0);
                Task<List<OtherTransport>> OtherTransports(int pipelineStepId, int limit = int.MaxValue, int offset = 0);
                Task<List<PipelineStepDestination>> PipelineStepDestinations(int pipelineStepId, int limit = int.MaxValue, int offset = 0);
                Task<List<PipelineStepNote>> PipelineStepNotes(int pipelineStepId, int limit = int.MaxValue, int offset = 0);
                Task<List<PipelineStepStepRequirement>> PipelineStepStepRequirements(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

                Task<PipelineStepStatus> GetPipelineStepStatus(int pipelineStepStatusId);
                Task<Employee> GetEmployee(int shipperId);
        }
}

/*<Codenesium>
    <Hash>b02e8d87fdc9870f9b68d4d1b739ff9e</Hash>
</Codenesium>*/