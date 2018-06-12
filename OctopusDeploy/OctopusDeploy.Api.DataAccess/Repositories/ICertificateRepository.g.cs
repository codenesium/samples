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

                Task<List<Certificate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<Certificate>> GetCreated(DateTime created);
                Task<List<Certificate>> GetDataVersion(byte[] dataVersion);
                Task<List<Certificate>> GetNotAfter(DateTime notAfter);
                Task<List<Certificate>> GetThumbprint(string thumbprint);
        }
}

/*<Codenesium>
    <Hash>5a1fbfe9024d98bf1bccc0f1f6c85691</Hash>
</Codenesium>*/