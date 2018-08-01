using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IInvitationRepository
	{
		Task<Invitation> Create(Invitation item);

		Task Update(Invitation item);

		Task Delete(string id);

		Task<Invitation> Get(string id);

		Task<List<Invitation>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e1f10b1110108e537c4ccdb04ed4be0b</Hash>
</Codenesium>*/