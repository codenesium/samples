using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public interface IApiUsersRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiUsersRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiUsersRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>c98d5d8070ed20c69be743e8b556df83</Hash>
</Codenesium>*/