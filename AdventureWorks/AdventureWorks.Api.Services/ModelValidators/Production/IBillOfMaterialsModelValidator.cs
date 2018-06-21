using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IApiBillOfMaterialsRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiBillOfMaterialsRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(int id, ApiBillOfMaterialsRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(int id);
        }
}

/*<Codenesium>
    <Hash>170808ed73f67df73364a98a225a8e63</Hash>
</Codenesium>*/