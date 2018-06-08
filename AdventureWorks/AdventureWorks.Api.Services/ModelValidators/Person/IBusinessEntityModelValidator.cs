using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiBusinessEntityRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>d50f65ff51113372bf15bb735d43aaa7</Hash>
</Codenesium>*/