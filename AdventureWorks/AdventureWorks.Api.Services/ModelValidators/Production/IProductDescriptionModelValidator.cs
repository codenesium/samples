using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiProductDescriptionRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProductDescriptionRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductDescriptionRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>b4e0983591bacf07b887a20d5d841890</Hash>
</Codenesium>*/