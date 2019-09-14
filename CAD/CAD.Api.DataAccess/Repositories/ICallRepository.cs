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

		Task<List<CallAssignment>> CallAssignmentsByCallId(int callId, int limit = int.MaxValue, int offset = 0);

		Task<List<Note>> NotesByCallId(int callId, int limit = int.MaxValue, int offset = 0);

		Task<Address> AddressByAddressId(int? addressId);

		Task<CallDisposition> CallDispositionByCallDispositionId(int? callDispositionId);

		Task<CallStatus> CallStatusByCallStatusId(int? callStatusId);

		Task<CallType> CallTypeByCallTypeId(int? callTypeId);
	}
}

/*<Codenesium>
    <Hash>0ec5a302594800b1f0f51e0f1a8a72e1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/