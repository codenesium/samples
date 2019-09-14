using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface INoteRepository
	{
		Task<Note> Create(Note item);

		Task Update(Note item);

		Task Delete(int id);

		Task<Note> Get(int id);

		Task<List<Note>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Call> CallByCallId(int callId);

		Task<Officer> OfficerByOfficerId(int officerId);
	}
}

/*<Codenesium>
    <Hash>0454639ffc0455957ca82795246a397a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/