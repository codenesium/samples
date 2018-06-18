using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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
    <Hash>941e61ff3d16ab914e9a37835eb3941a</Hash>
</Codenesium>*/