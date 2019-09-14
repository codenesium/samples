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

		Task<List<File>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Bucket> BucketByBucketId(int? bucketId);

		Task<FileType> FileTypeByFileTypeId(int fileTypeId);
	}
}

/*<Codenesium>
    <Hash>6826aa2fbb3c8bf6af6de29600f3638c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/