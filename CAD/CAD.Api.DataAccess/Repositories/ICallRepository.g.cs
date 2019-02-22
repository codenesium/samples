using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface ICallRepository
	{
		Task<Call> Create(Call item);

		Task Update(Call item);

		Task Delete(int id);

		Task<Call> Get(int id);

		Task<List<Call>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Note>> NotesByCallId(int callId, int limit = int.MaxValue, int offset = 0);

		Task<List<CallAssignment>> CallAssignmentsByCallId(int callId, int limit = int.MaxValue, int offset = 0);

		Task<Address> AddressByAddressId(int? addressId);

		Task<CallDisposition> CallDispositionByCallDispositionId(int? callDispositionId);

		Task<CallStatu> CallStatuByCallStatusId(int? callStatusId);

		Task<CallType> CallTypeByCallTypeId(int? callTypeId);
	}
}

/*<Codenesium>
    <Hash>e8ce8da915f3a4d33ec04422a8fb4339</Hash>
</Codenesium>*/