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

                Task<List<TagSet>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<TagSet> GetName(string name);
                Task<List<TagSet>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>67ba40c78c36dc93c61cdb6557bf17cd</Hash>
</Codenesium>*/