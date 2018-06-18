using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IPhoneNumberTypeRepository
        {
                Task<PhoneNumberType> Create(PhoneNumberType item);

                Task Update(PhoneNumberType item);

                Task Delete(int phoneNumberTypeID);

                Task<PhoneNumberType> Get(int phoneNumberTypeID);

                Task<List<PhoneNumberType>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<PersonPhone>> PersonPhones(int phoneNumberTypeID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>bb6c03e3ede4be342aa49f31ae96e323</Hash>
</Codenesium>*/