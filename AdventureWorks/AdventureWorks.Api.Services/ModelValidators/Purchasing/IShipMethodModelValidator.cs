using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiShipMethodRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiShipMethodRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiShipMethodRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>2d8fe68e7077748f727c014ba9e7174d</Hash>
</Codenesium>*/