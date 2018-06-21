using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiContactTypeRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiContactTypeRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiContactTypeRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>ee56ea4d8dc3dcf151559c5e98c603ec</Hash>
</Codenesium>*/