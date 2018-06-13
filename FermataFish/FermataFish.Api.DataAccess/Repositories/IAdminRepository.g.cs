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

                Task<List<Admin>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>20233e86ad69889f206085a3818faf76</Hash>
</Codenesium>*/