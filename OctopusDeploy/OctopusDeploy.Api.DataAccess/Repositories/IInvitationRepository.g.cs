using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IInvitationRepository
        {
                Task<Invitation> Create(Invitation item);

                Task Update(Invitation item);

                Task Delete(string id);

                Task<Invitation> Get(string id);

                Task<List<Invitation>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>321fa1b4b2961dba6e1032288e822aea</Hash>
</Codenesium>*/