using FileServiceNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
        public interface IApiFileTypeRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiFileTypeRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileTypeRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>c686e936c124a47f9f9cd48d30cfd789</Hash>
</Codenesium>*/