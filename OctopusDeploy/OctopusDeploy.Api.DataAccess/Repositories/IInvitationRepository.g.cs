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

                Task<List<Invitation>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>8d7d5f7b0d32367d6277c8c75af6f152</Hash>
</Codenesium>*/