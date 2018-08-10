using Codenesium.DataConversionExtensions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public abstract class AbstractFileService : AbstractService
	{
		protected IFileRepository FileRepository { get; private set; }

		protected IApiFileRequestModelValidator FileModelValidator { get; private set; }

		protected IBOLFileMapper BolFileMapper { get; private set; }

		protected IDALFileMapper DalFileMapper { get; private set; }

		private ILogger logger;

		public AbstractFileService(
			ILogger logger,
			IFileRepository fileRepository,
			IApiFileRequestModelValidator fileModelValidator,
			IBOLFileMapper bolFileMapper,
			IDALFileMapper dalFileMapper)
			: base()
		{
			this.FileRepository = fileRepository;
			this.FileModelValidator = fileModelValidator;
			this.BolFileMapper = bolFileMapper;
			this.DalFileMapper = dalFileMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiFileResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.FileRepository.All(limit, offset);

			return this.BolFileMapper.MapBOToModel(this.DalFileMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiFileResponseModel> Get(int id)
		{
			var record = await this.FileRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolFileMapper.MapBOToModel(this.DalFileMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiFileResponseModel>> Create(
			ApiFileRequestModel model)
		{
			CreateResponse<ApiFileResponseModel> response = new CreateResponse<ApiFileResponseModel>(await this.FileModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolFileMapper.MapModelToBO(default(int), model);
				var record = await this.FileRepository.Create(this.DalFileMapper.MapBOToEF(bo));

				response.SetRecord(this.BolFileMapper.MapBOToModel(this.DalFileMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiFileResponseModel>> Update(
			int id,
			ApiFileRequestModel model)
		{
			var validationResult = await this.FileModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolFileMapper.MapModelToBO(id, model);
				await this.FileRepository.Update(this.DalFileMapper.MapBOToEF(bo));

				var record = await this.FileRepository.Get(id);

				return new UpdateResponse<ApiFileResponseModel>(this.BolFileMapper.MapBOToModel(this.DalFileMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiFileResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.FileModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.FileRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>f4c1233a5683193bd97ec26e9366c538</Hash>
</Codenesium>*/