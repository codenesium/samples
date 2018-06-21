using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>ca03af652892e57beab44c18c25c7b99</Hash>
</Codenesium>*/