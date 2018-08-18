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

		Task<List<TagSet>> ByDataVersion(byte[] dataVersion, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>815fbd73df41cf9e56fcae7928f72a8e</Hash>
</Codenesium>*/