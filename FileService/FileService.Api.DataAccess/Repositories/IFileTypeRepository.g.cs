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
    <Hash>c4f8c22990f5f0074084c74a1aaf932d</Hash>
</Codenesium>*/