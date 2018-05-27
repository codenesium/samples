using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IFileRepository
	{
		Task<DTOFile> Create(DTOFile dto);

		Task Update(int id,
		            DTOFile dto);

		Task Delete(int id);

		Task<DTOFile> Get(int id);

		Task<List<DTOFile>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>eb87b2d7572c8d1efa87ce62ac061ab5</Hash>
</Codenesium>*/