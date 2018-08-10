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

		Task<List<ClientCommunication>> ClientCommunications(int employeeId, int limit = int.MaxValue, int offset = 0);

		Task<List<PipelineStep>> PipelineSteps(int shipperId, int limit = int.MaxValue, int offset = 0);

		Task<List<PipelineStepNote>> PipelineStepNotes(int employeeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c47f13d5ec1ff4569521fa7414b3b4c4</Hash>
</Codenesium>*/