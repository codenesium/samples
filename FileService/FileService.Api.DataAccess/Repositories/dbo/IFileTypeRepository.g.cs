using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IFileTypeRepository
	{
		Task<POCOFileType> Create(ApiFileTypeModel model);

		Task Update(int id,
		            ApiFileTypeModel model);

		Task Delete(int id);

		Task<POCOFileType> Get(int id);

		Task<List<POCOFileType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>11e833e6a4df1bea1e8efa9530c68ff6</Hash>
</Codenesium>*/