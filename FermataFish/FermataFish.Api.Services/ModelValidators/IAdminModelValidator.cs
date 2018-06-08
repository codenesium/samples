using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.Services
{
        public interface IApiAdminRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiAdminRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiAdminRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>816531bef38fda82bcf9c2be967c9536</Hash>
</Codenesium>*/