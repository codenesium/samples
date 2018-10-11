using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
{
	public partial interface IFileRepository
	{
		Task<File> Create(File item);

		Task Update(File item);

		Task Delete(int id);

		Task<File> Get(int id);

		Task<List<File>> All(int limit = int.MaxValue, int offset = 0);

		Task<Bucket> BucketByBucketId(int? bucketId);

		Task<FileType> FileTypeByFileTypeId(int fileTypeId);
	}
}

/*<Codenesium>
    <Hash>257af16483c5bd384ac41ef43fb653d4</Hash>
</Codenesium>*/