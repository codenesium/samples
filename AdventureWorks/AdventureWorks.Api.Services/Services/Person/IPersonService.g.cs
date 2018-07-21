using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IPersonService
        {
                Task<CreateResponse<ApiPersonResponseModel>> Create(
                        ApiPersonRequestModel model);

                Task<UpdateResponse<ApiPersonResponseModel>> Update(int businessEntityID,
                                                                     ApiPersonRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiPersonResponseModel> Get(int businessEntityID);

                Task<List<ApiPersonResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPersonResponseModel>> ByLastNameFirstNameMiddleName(string lastName, string firstName, string middleName);

                Task<List<ApiPersonResponseModel>> ByAdditionalContactInfo(string additionalContactInfo);

                Task<List<ApiPersonResponseModel>> ByDemographic(string demographic);

                Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContacts(int personID, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiEmailAddressResponseModel>> EmailAddresses(int businessEntityID, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPasswordResponseModel>> Passwords(int businessEntityID, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPersonPhoneResponseModel>> PersonPhones(int businessEntityID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>85ff934d24867dffd93fc71534a9e787</Hash>
</Codenesium>*/