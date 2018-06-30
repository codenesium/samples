using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>7586f1a6a2c3d8f25b64ba4ef79bd852</Hash>
</Codenesium>*/