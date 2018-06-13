using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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

                Task<List<ApiPersonResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiPersonResponseModel>> GetLastNameFirstNameMiddleName(string lastName, string firstName, string middleName);
                Task<List<ApiPersonResponseModel>> GetAdditionalContactInfo(string additionalContactInfo);
                Task<List<ApiPersonResponseModel>> GetDemographics(string demographics);

                Task<List<ApiBusinessEntityContactResponseModel>> BusinessEntityContacts(int personID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiEmailAddressResponseModel>> EmailAddresses(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiPasswordResponseModel>> Passwords(int businessEntityID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiPersonPhoneResponseModel>> PersonPhones(int businessEntityID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>821890c02442e17914ffcda9c7d83e23</Hash>
</Codenesium>*/