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

namespace FileServiceNS.Api.Services
{
	public abstract class AbstractFileTypeService: AbstractService
	{
		private IFileTypeRepository fileTypeRepository;
		private IApiFileTypeRequestModelValidator fileTypeModelValidator;
		private IBOLFileTypeMapper BOLFileTypeMapper;
		private IDALFileTypeMapper DALFileTypeMapper;
		private ILogger logger;

		public AbstractFileTypeService(
			ILogger logger,
			IFileTypeRepository fileTypeRepository,
			IApiFileTypeRequestModelValidator fileTypeModelValidator,
			IBOLFileTypeMapper bolfileTypeMapper,
			IDALFileTypeMapper dalfileTypeMapper)
			: base()

		{
			this.fileTypeRepository = fileTypeRepository;
			this.fileTypeModelValidator = fileTypeModelValidator;
			this.BOLFileTypeMapper = bolfileTypeMapper;
			this.DALFileTypeMapper = dalfileTypeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiFileTypeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.fileTypeRepository.All(skip, take, orderClause);

			return this.BOLFileTypeMapper.MapBOToModel(this.DALFileTypeMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiFileTypeResponseModel> Get(int id)
		{
			var record = await fileTypeRepository.Get(id);

			return this.BOLFileTypeMapper.MapBOToModel(this.DALFileTypeMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiFileTypeResponseModel>> Create(
			ApiFileTypeRequestModel model)
		{
			CreateResponse<ApiFileTypeResponseModel> response = new CreateResponse<ApiFileTypeResponseModel>(await this.fileTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLFileTypeMapper.MapModelToBO(default (int), model);
				var record = await this.fileTypeRepository.Create(this.DALFileTypeMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLFileTypeMapper.MapBOToModel(this.DALFileTypeMapper.MapEFToBO(record)));
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
				var bo = this.BOLFileTypeMapper.MapModelToBO(id, model);
				await this.fileTypeRepository.Update(this.DALFileTypeMapper.MapBOToEF(bo));
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
    <Hash>30d209e1143c83640b8231566c9f294c</Hash>
</Codenesium>*/