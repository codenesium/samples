using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public interface IBOVersionInfo
	{
		Task<CreateResponse<POCOVersionInfo>> Create(
			ApiVersionInfoModel model);

		Task<ActionResponse> Update(long version,
		                            ApiVersionInfoModel model);

		Task<ActionResponse> Delete(long version);

		Task<POCOVersionInfo> Get(long version);

		Task<List<POCOVersionInfo>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOVersionInfo> Version(long version);
	}
}

/*<Codenesium>
    <Hash>1fd9020cf24f681c114ce89fbc992c47</Hash>
</Codenesium>*/