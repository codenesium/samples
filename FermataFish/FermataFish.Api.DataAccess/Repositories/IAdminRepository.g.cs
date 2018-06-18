using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface IAdminRepository
        {
                Task<Admin> Create(Admin item);

                Task Update(Admin item);

                Task Delete(int id);

                Task<Admin> Get(int id);

                Task<List<Admin>> All(int limit = int.MaxValue, int offset = 0);

                Task<Studio> GetStudio(int studioId);
        }
}

/*<Codenesium>
    <Hash>b71c2ca2aba1d56bb1274b3af820731f</Hash>
</Codenesium>*/