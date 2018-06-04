using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
{
	public interface IFileTypeRepository
	{
		Task<FileType> Create(FileType item);

		Task Update(FileType item);

		Task Delete(int id);

		Task<FileType> Get(int id);

		Task<List<FileType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>da95725e8e88546d7e0b47b49bbd5de8</Hash>
</Codenesium>*/