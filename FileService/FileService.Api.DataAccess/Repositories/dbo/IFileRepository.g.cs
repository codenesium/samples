using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IFileRepository
	{
		Task<POCOFile> Create(ApiFileModel model);

		Task Update(int id,
		            ApiFileModel model);

		Task Delete(int id);

		Task<POCOFile> Get(int id);

		Task<List<POCOFile>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6dcb4e851a95c959017cd7665db8a6d1</Hash>
</Codenesium>*/