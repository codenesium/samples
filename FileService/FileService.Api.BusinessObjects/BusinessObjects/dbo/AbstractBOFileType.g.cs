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
	public abstract class AbstractBOFileType: AbstractBOManager
	{
		private IFileTypeRepository fileTypeRepository;
		private IApiFileTypeRequestModelValidator fileTypeModelValidator;
		private IBOLFileTypeMapper fileTypeMapper;
		private ILogger logger;

		public AbstractBOFileType(
			ILogger logger,
			IFileTypeRepository fileTypeRepository,
			IApiFileTypeRequestModelValidator fileTypeModelValidator,
			IBOLFileTypeMapper fileTypeMapper)
			: base()

		{
			this.fileTypeRepository = fileTypeRepository;
			this.fileTypeModelValidator = fileTypeModelValidator;
			this.fileTypeMapper = fileTypeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiFileTypeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.fileTypeRepository.All(skip, take, orderClause);

			return this.fileTypeMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiFileTypeResponseModel> Get(int id)
		{
			var record = await fileTypeRepository.Get(id);

			return this.fileTypeMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiFileTypeResponseModel>> Create(
			ApiFileTypeRequestModel model)
		{
			CreateResponse<ApiFileTypeResponseModel> response = new CreateResponse<ApiFileTypeResponseModel>(await this.fileTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.fileTypeMapper.MapModelToDTO(default (int), model);
				var record = await this.fileTypeRepository.Create(dto);

				response.SetRecord(this.fileTypeMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiFileTypeRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.fileTypeModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.fileTypeMapper.MapModelToDTO(id, model);
				await this.fileTypeRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.fileTypeModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.fileTypeRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d9d7639db421c6a80602793ac46f32b6</Hash>
</Codenesium>*/