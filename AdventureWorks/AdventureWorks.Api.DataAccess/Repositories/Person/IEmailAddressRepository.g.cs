using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IEmailAddressRepository
        {
                Task<EmailAddress> Create(EmailAddress item);

                Task Update(EmailAddress item);

                Task Delete(int businessEntityID);

                Task<EmailAddress> Get(int businessEntityID);

                Task<List<EmailAddress>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<EmailAddress>> ByEmailAddress(string emailAddress1);
        }
}

/*<Codenesium>
    <Hash>127b0e907c5c4d7bd2d4d35f2494f3c1</Hash>
</Codenesium>*/