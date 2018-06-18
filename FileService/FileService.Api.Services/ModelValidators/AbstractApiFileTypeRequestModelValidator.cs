using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public abstract class AbstractApiFileTypeRequestModelValidator: AbstractValidator<ApiFileTypeRequestModel>
        {
                private int existingRecordId;

                IFileTypeRepository fileTypeRepository;

                public AbstractApiFileTypeRequestModelValidator(IFileTypeRepository fileTypeRepository)
                {
                        this.fileTypeRepository = fileTypeRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiFileTypeRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 255);
                }
        }
}

/*<Codenesium>
    <Hash>d805ad9bedb0a5b22c4e49ab430caae8</Hash>
</Codenesium>*/