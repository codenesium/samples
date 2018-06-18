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

                Task<List<TagSet>> All(int limit = int.MaxValue, int offset = 0);

                Task<TagSet> GetName(string name);
                Task<List<TagSet>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>dae2265c1ac585fef49525b9f470d493</Hash>
</Codenesium>*/