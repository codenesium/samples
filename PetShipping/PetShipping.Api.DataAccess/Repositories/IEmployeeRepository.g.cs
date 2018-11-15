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

		Task<List<PipelineStep>> PipelineStepsByShipperId(int shipperId, int limit = int.MaxValue, int offset = 0);

		Task<List<PipelineStepNote>> PipelineStepNotesByEmployeeId(int employeeId, int limit = int.MaxValue, int offset = 0);

		Task<List<CustomerCommunication>> CustomerCommunicationsByEmployeeId(int employeeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7a5c6ab9ab5a77b212011e9f29622c6c</Hash>
</Codenesium>*/