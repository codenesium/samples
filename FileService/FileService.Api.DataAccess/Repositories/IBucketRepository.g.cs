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

		Task<List<Bucket>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Bucket> ByExternalId(Guid externalId);

		Task<Bucket> ByName(string name);

		Task<List<File>> FilesByBucketId(int bucketId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>83db570ce889fd9a38a749e1dc7c3c37</Hash>
</Codenesium>*/