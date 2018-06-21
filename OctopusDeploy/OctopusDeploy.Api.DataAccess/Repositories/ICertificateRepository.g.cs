using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface ICertificateRepository
        {
                Task<Certificate> Create(Certificate item);

                Task Update(Certificate item);

                Task Delete(string id);

                Task<Certificate> Get(string id);

                Task<List<Certificate>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Certificate>> GetCreated(DateTimeOffset created);

                Task<List<Certificate>> GetDataVersion(byte[] dataVersion);

                Task<List<Certificate>> GetNotAfter(DateTimeOffset notAfter);

                Task<List<Certificate>> GetThumbprint(string thumbprint);
        }
}

/*<Codenesium>
    <Hash>1abd8001d4e8a36594fbecf9b57d8758</Hash>
</Codenesium>*/