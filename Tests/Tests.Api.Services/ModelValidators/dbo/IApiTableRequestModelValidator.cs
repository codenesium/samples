using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
        public interface IApiTableRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTableRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiTableRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>31df3aee2a87d22b1393b3b43e9a9d42</Hash>
</Codenesium>*/