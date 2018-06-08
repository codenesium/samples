using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IPersonRepository
        {
                Task<Person> Create(Person item);

                Task Update(Person item);

                Task Delete(int businessEntityID);

                Task<Person> Get(int businessEntityID);

                Task<List<Person>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<Person>> GetLastNameFirstNameMiddleName(string lastName, string firstName, string middleName);
                Task<List<Person>> GetAdditionalContactInfo(string additionalContactInfo);
                Task<List<Person>> GetDemographics(string demographics);
        }
}

/*<Codenesium>
    <Hash>b5873e88bb9fb62e7badbe9cc1598dc8</Hash>
</Codenesium>*/