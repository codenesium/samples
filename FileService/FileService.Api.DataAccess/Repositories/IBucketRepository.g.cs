using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
{
        public interface IBucketRepository
        {
                Task<Bucket> Create(Bucket item);

                Task Update(Bucket item);

                Task Delete(int id);

                Task<Bucket> Get(int id);

                Task<List<Bucket>> All(int limit = int.MaxValue, int offset = 0);

                Task<Bucket> GetExternalId(Guid externalId);

                Task<Bucket> GetName(string name);

                Task<List<File>> Files(int bucketId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d1b812f6b1d73e616da3f5f3423908b5</Hash>
</Codenesium>*/