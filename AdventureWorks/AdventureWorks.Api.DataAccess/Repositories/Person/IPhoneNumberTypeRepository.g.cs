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

                Task<List<PhoneNumberType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>9e3453dcd9c15d582b27d67aae96a8fe</Hash>
</Codenesium>*/