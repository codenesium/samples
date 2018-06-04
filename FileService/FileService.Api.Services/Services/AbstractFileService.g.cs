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
	public abstract class AbstractFileService: AbstractService
	{
		private IFileRepository fileRepository;
		private IApiFileRequestModelValidator fileModelValidator;
		private IBOLFileMapper BOLFileMapper;
		private IDALFileMapper DALFileMapper;
		private ILogger logger;

		public AbstractFileService(
			ILogger logger,
			IFileRepository fileRepository,
			IApiFileRequestModelValidator fileModelValidator,
			IBOLFileMapper bolfileMapper,
			IDALFileMapper dalfileMapper)
			: base()

		{
			this.fileRepository = fileRepository;
			this.fileModelValidator = fileModelValidator;
			this.BOLFileMapper = bolfileMapper;
			this.DALFileMapper = dalfileMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiFileResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.fileRepository.All(skip, take, orderClause);

			return this.BOLFileMapper.MapBOToModel(this.DALFileMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiFileResponseModel> Get(int id)
		{
			var record = await fileRepository.Get(id);

			return this.BOLFileMapper.MapBOToModel(this.DALFileMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiFileResponseModel>> Create(
			ApiFileRequestModel model)
		{
			CreateResponse<ApiFileResponseModel> response = new CreateResponse<ApiFileResponseModel>(await this.fileModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLFileMapper.MapModelToBO(default (int), model);
				var record = await this.fileRepository.Create(this.DALFileMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLFileMapper.MapBOToModel(this.DALFileMapper.MapEFToBO(record)));
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
				var bo = this.BOLFileMapper.MapModelToBO(id, model);
				await this.fileRepository.Update(this.DALFileMapper.MapBOToEF(bo));
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
    <Hash>6158a18bdd8b53e4d7e55d56527a6403</Hash>
</Codenesium>*/