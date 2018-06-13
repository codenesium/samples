using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface ITagSetRepository
        {
                Task<TagSet> Create(TagSet item);

                Task Update(TagSet item);

                Task Delete(string id);

                Task<TagSet> Get(string id);

                Task<List<TagSet>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<TagSet> GetName(string name);
                Task<List<TagSet>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>a8e895895f36b179c376d40b4be8ac0b</Hash>
</Codenesium>*/