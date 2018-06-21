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

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiPersonRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiPersonResponseModel> Get(int businessEntityID);

                Task<List<ApiPersonResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPersonResponseModel>> ByLastNameFirstNameMiddleName(string lastName, string firstName, string middleName);

                Task<List<ApiPersonResponseModel>> ByAdditionalContactInfo(string additionalContactInfo);

                Task<List<ApiPersonResponseModel>> ByDemographics(string demographics);

                Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContacts(int personID, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiEmailAddressResponseModel>> EmailAddresses(int businessEntityID, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPasswordResponseModel>> Passwords(int businessEntityID, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPersonPhoneResponseModel>> PersonPhones(int businessEntityID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>ad55db55bdfb6a748d37892a444e5e68</Hash>
</Codenesium>*/