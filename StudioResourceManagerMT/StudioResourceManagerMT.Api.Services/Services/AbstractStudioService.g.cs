using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractStudioService : AbstractService
	{
		protected IStudioRepository StudioRepository { get; private set; }

		protected IApiStudioServerRequestModelValidator StudioModelValidator { get; private set; }

		protected IBOLStudioMapper BolStudioMapper { get; private set; }

		protected IDALStudioMapper DalStudioMapper { get; private set; }

		private ILogger logger;

		public AbstractStudioService(
			ILogger logger,
			IStudioRepository studioRepository,
			IApiStudioServerRequestModelValidator studioModelValidator,
			IBOLStudioMapper bolStudioMapper,
			IDALStudioMapper dalStudioMapper)
			: base()
		{
			this.StudioRepository = studioRepository;
			this.StudioModelValidator = studioModelValidator;
			this.BolStudioMapper = bolStudioMapper;
			this.DalStudioMapper = dalStudioMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStudioServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.StudioRepository.All(limit, offset);

			return this.BolStudioMapper.MapBOToModel(this.DalStudioMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiStudioServerResponseModel> Get(int id)
		{
			var record = await this.StudioRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolStudioMapper.MapBOToModel(this.DalStudioMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiStudioServerResponseModel>> Create(
			ApiStudioServerRequestModel model)
		{
			CreateResponse<ApiStudioServerResponseModel> response = ValidationResponseFactory<ApiStudioServerResponseModel>.CreateResponse(await this.StudioModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolStudioMapper.MapModelToBO(default(int), model);
				var record = await this.StudioRepository.Create(this.DalStudioMapper.MapBOToEF(bo));

				response.SetRecord(this.BolStudioMapper.MapBOToModel(this.DalStudioMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiStudioServerResponseModel>> Update(
			int id,
			ApiStudioServerRequestModel model)
		{
			var validationResult = await this.StudioModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolStudioMapper.MapModelToBO(id, model);
				await this.StudioRepository.Update(this.DalStudioMapper.MapBOToEF(bo));

				var record = await this.StudioRepository.Get(id);

				return ValidationResponseFactory<ApiStudioServerResponseModel>.UpdateResponse(this.BolStudioMapper.MapBOToModel(this.DalStudioMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiStudioServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.StudioModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.StudioRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9dadbceed8b0ab3f2ff8a9a23ef994cb</Hash>
</Codenesium>*/