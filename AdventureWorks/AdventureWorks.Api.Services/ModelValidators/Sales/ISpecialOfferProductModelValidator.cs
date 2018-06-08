using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiSpecialOfferProductRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSpecialOfferProductRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpecialOfferProductRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>2939fd529cab1ed682e74580a665192f</Hash>
</Codenesium>*/