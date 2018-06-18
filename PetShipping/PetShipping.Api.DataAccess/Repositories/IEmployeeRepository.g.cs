using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IEmployeeRepository
        {
                Task<Employee> Create(Employee item);

                Task Update(Employee item);

                Task Delete(int id);

                Task<Employee> Get(int id);

                Task<List<Employee>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ClientCommunication>> ClientCommunications(int employeeId, int limit = int.MaxValue, int offset = 0);
                Task<List<PipelineStep>> PipelineSteps(int shipperId, int limit = int.MaxValue, int offset = 0);
                Task<List<PipelineStepNote>> PipelineStepNotes(int employeeId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>c64f74ac3bd9279e4d7b538992fa0def</Hash>
</Codenesium>*/