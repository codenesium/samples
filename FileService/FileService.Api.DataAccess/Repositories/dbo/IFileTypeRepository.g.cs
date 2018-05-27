using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IFileTypeRepository
	{
		Task<DTOFileType> Create(DTOFileType dto);

		Task Update(int id,
		            DTOFileType dto);

		Task Delete(int id);

		Task<DTOFileType> Get(int id);

		Task<List<DTOFileType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>52489f49f8749b067a1f5140f8227abe</Hash>
</Codenesium>*/