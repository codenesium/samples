using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IEmployeeRepository
	{
		Task<Employee> Create(Employee item);

		Task Update(Employee item);

		Task Delete(int id);

		Task<Employee> Get(int id);

		Task<List<Employee>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ClientCommunication>> ClientCommunicationsByEmployeeId(int employeeId, int limit = int.MaxValue, int offset = 0);

		Task<List<PipelineStep>> PipelineStepsByShipperId(int shipperId, int limit = int.MaxValue, int offset = 0);

		Task<List<PipelineStepNote>> PipelineStepNotesByEmployeeId(int employeeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d9ea42e4f4383182785a0306c3f976fb</Hash>
</Codenesium>*/