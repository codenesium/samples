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

                Task<List<Invitation>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>ff6c5c3fedf1b3c4289bbfee12ec8cf8</Hash>
</Codenesium>*/