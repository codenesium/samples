using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public abstract class AbstractBOFileType
	{
		private IFileTypeRepository fileTypeRepository;
		private IFileTypeModelValidator fileTypeModelValidator;
		private ILogger logger;

		public AbstractBOFileType(
			ILogger logger,
			IFileTypeRepository fileTypeRepository,
			IFileTypeModelValidator fileTypeModelValidator)

		{
			this.fileTypeRepository = fileTypeRepository;
			this.fileTypeModelValidator = fileTypeModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			FileTypeModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.fileTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.fileTypeRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			FileTypeModel model)
		{
			ActionResponse response = new ActionResponse(await this.fileTypeModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.fileTypeRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.fileTypeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.fileTypeRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOFileType Get(int id)
		{
			return this.fileTypeRepository.Get(id);
		}

		public virtual List<POCOFileType> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.fileTypeRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>c3fa356276e156c3bea596fce20db3a8</Hash>
</Codenesium>*/