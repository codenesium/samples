using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
{
	public partial interface IFileTypeRepository
	{
		Task<FileType> Create(FileType item);

		Task Update(FileType item);

		Task Delete(int id);

		Task<FileType> Get(int id);

		Task<List<FileType>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<File>> Files(int fileTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ad2e52abd2418d01a5940ec917b6ee51</Hash>
</Codenesium>*/