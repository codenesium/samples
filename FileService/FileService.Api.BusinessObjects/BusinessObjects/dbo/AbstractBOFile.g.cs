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
		private IApiFileRequestModelValidator fileModelValidator;
		private IBOLFileMapper fileMapper;
		private ILogger logger;

		public AbstractBOFile(
			ILogger logger,
			IFileRepository fileRepository,
			IApiFileRequestModelValidator fileModelValidator,
			IBOLFileMapper fileMapper)
			: base()

		{
			this.fileRepository = fileRepository;
			this.fileModelValidator = fileModelValidator;
			this.fileMapper = fileMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiFileResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.fileRepository.All(skip, take, orderClause);

			return this.fileMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiFileResponseModel> Get(int id)
		{
			var record = await fileRepository.Get(id);

			return this.fileMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiFileResponseModel>> Create(
			ApiFileRequestModel model)
		{
			CreateResponse<ApiFileResponseModel> response = new CreateResponse<ApiFileResponseModel>(await this.fileModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.fileMapper.MapModelToDTO(default (int), model);
				var record = await this.fileRepository.Create(dto);

				response.SetRecord(this.fileMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiFileRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.fileModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.fileMapper.MapModelToDTO(id, model);
				await this.fileRepository.Update(id, dto);
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
    <Hash>7ed2c1e97bb0558f0333d40c0e09c1b8</Hash>
</Codenesium>*/