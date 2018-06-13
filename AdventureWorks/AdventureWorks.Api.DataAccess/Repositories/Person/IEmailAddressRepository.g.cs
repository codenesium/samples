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

                Task<List<EmailAddress>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<EmailAddress>> GetEmailAddress(string emailAddress1);
        }
}

/*<Codenesium>
    <Hash>ab69651e3f7f2ad07d502094548750dc</Hash>
</Codenesium>*/