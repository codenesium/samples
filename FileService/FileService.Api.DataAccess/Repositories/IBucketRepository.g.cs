using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
{
        public interface IBucketRepository
        {
                Task<Bucket> Create(Bucket item);

                Task Update(Bucket item);

                Task Delete(int id);

                Task<Bucket> Get(int id);

                Task<List<Bucket>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Bucket> GetExternalId(Guid externalId);
                Task<Bucket> GetName(string name);

                Task<List<File>> Files(int bucketId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>9879f3ba3e1aa2e0e436dc7a60411f93</Hash>
</Codenesium>*/