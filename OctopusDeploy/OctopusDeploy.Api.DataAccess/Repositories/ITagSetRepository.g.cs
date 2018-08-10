using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface ITagSetRepository
	{
		Task<TagSet> Create(TagSet item);

		Task Update(TagSet item);

		Task Delete(string id);

		Task<TagSet> Get(string id);

		Task<List<TagSet>> All(int limit = int.MaxValue, int offset = 0);

		Task<TagSet> ByName(string name);

		Task<List<TagSet>> ByDataVersion(byte[] dataVersion);
	}
}

/*<Codenesium>
    <Hash>b595190df1cd6cfbe43a6fc27beed07d</Hash>
</Codenesium>*/