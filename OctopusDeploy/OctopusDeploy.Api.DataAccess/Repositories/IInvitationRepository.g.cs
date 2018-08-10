using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IInvitationRepository
	{
		Task<Invitation> Create(Invitation item);

		Task Update(Invitation item);

		Task Delete(string id);

		Task<Invitation> Get(string id);

		Task<List<Invitation>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>4dd62f250f6ff2314a7574802e09ad5d</Hash>
</Codenesium>*/