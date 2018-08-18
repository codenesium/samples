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

		Task<List<Certificate>> ByCreated(DateTimeOffset created, int limit = int.MaxValue, int offset = 0);

		Task<List<Certificate>> ByDataVersion(byte[] dataVersion, int limit = int.MaxValue, int offset = 0);

		Task<List<Certificate>> ByNotAfter(DateTimeOffset notAfter, int limit = int.MaxValue, int offset = 0);

		Task<List<Certificate>> ByThumbprint(string thumbprint, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9fc4fd9593ceb00b4b91aaf726fb587e</Hash>
</Codenesium>*/