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

                Task<List<EmailAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<EmailAddress>> GetEmailAddress(string emailAddress1);
        }
}

/*<Codenesium>
    <Hash>698a0ca95b0d3dccad7a4c702e1104cb</Hash>
</Codenesium>*/