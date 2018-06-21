using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>80dea5362ecd997347e34aa183e222ab</Hash>
</Codenesium>*/