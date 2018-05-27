using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IVersionInfoRepository
	{
		Task<DTOVersionInfo> Create(DTOVersionInfo dto);

		Task Update(long version,
		            DTOVersionInfo dto);

		Task Delete(long version);

		Task<DTOVersionInfo> Get(long version);

		Task<List<DTOVersionInfo>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOVersionInfo> GetVersion(long version);
	}
}

/*<Codenesium>
    <Hash>065b230c85e01d2cf07200b507654ef6</Hash>
</Codenesium>*/