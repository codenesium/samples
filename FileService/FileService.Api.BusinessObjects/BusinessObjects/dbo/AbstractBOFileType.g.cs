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
		private IApiFileTypeModelValidator fileTypeModelValidator;
		private ILogger logger;

		public AbstractBOFileType(
			ILogger logger,
			IFileTypeRepository fileTypeRepository,
			IApiFileTypeModelValidator fileTypeModelValidator)

		{
			this.fileTypeRepository = fileTypeRepository;
			this.fileTypeModelValidator = fileTypeModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOFileType> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.fileTypeRepository.All(skip, take, orderClause);
		}

		public virtual POCOFileType Get(int id)
		{
			return this.fileTypeRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOFileType>> Create(
			ApiFileTypeModel model)
		{
			CreateResponse<POCOFileType> response = new CreateResponse<POCOFileType>(await this.fileTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOFileType record = this.fileTypeRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiFileTypeModel model)
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
	}
}

/*<Codenesium>
    <Hash>860fadddcdd4da6f240601b585cf738f</Hash>
</Codenesium>*/