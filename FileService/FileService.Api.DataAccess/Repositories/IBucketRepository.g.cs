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

		Task<Bucket> ByExternalId(Guid externalId);

		Task<Bucket> ByName(string name);

		Task<List<File>> Files(int bucketId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a03279657ee9574377d7406b7da8b130</Hash>
</Codenesium>*/