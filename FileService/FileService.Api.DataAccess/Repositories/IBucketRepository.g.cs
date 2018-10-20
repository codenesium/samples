using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
{
	public partial interface IBucketRepository
	{
		Task<Bucket> Create(Bucket item);

		Task Update(Bucket item);

		Task Delete(int id);

		Task<Bucket> Get(int id);

		Task<List<Bucket>> All(int limit = int.MaxValue, int offset = 0);

		Task<Bucket> ByExternalId(Guid externalId);

		Task<Bucket> ByName(string name);

		Task<List<File>> FilesByBucketId(int bucketId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>49c1b991f1d80a48a3555a4d23b39fed</Hash>
</Codenesium>*/