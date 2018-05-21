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
	public abstract class AbstractBOFile: AbstractBOManager
	{
		private IFileRepository fileRepository;
		private IApiFileModelValidator fileModelValidator;
		private ILogger logger;

		public AbstractBOFile(
			ILogger logger,
			IFileRepository fileRepository,
			IApiFileModelValidator fileModelValidator)
			: base()

		{
			this.fileRepository = fileRepository;
			this.fileModelValidator = fileModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOFile>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.fileRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOFile> Get(int id)
		{
			return this.fileRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOFile>> Create(
			ApiFileModel model)
		{
			CreateResponse<POCOFile> response = new CreateResponse<POCOFile>(await this.fileModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOFile record = await this.fileRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiFileModel model)
		{
			ActionResponse response = new ActionResponse(await this.fileModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.fileRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.fileModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.fileRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8850c4858aa04aae995c44eb238b940b</Hash>
</Codenesium>*/