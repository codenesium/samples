using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface ICertificateRepository
	{
		Task<Certificate> Create(Certificate item);

		Task Update(Certificate item);

		Task Delete(string id);

		Task<Certificate> Get(string id);

		Task<List<Certificate>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Certificate>> ByCreated(DateTimeOffset created);

		Task<List<Certificate>> ByDataVersion(byte[] dataVersion);

		Task<List<Certificate>> ByNotAfter(DateTimeOffset notAfter);

		Task<List<Certificate>> ByThumbprint(string thumbprint);
	}
}

/*<Codenesium>
    <Hash>926041fa80f65a5c122fd8fae5450c27</Hash>
</Codenesium>*/