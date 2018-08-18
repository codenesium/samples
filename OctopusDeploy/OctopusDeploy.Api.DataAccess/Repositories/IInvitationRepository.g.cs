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
    <Hash>4451fa2fc4a6dddf3152c63ebfaf737e</Hash>
</Codenesium>*/