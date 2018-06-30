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
    <Hash>39af029e1eddb7ac634e4cde866d2ae8</Hash>
</Codenesium>*/