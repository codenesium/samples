using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractSpaceService : AbstractService
	{
		protected ISpaceRepository SpaceRepository { get; private set; }

		protected IApiSpaceServerRequestModelValidator SpaceModelValidator { get; private set; }

		protected IBOLSpaceMapper BolSpaceMapper { get; private set; }

		protected IDALSpaceMapper DalSpaceMapper { get; private set; }

		private ILogger logger;

		public AbstractSpaceService(
			ILogger logger,
			ISpaceRepository spaceRepository,
			IApiSpaceServerRequestModelValidator spaceModelValidator,
			IBOLSpaceMapper bolSpaceMapper,
			IDALSpaceMapper dalSpaceMapper)
			: base()
		{
			this.SpaceRepository = spaceRepository;
			this.SpaceModelValidator = spaceModelValidator;
			this.BolSpaceMapper = bolSpaceMapper;
			this.DalSpaceMapper = dalSpaceMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpaceServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SpaceRepository.All(limit, offset);

			return this.BolSpaceMapper.MapBOToModel(this.DalSpaceMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSpaceServerResponseModel> Get(int id)
		{
			var record = await this.SpaceRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSpaceMapper.MapBOToModel(this.DalSpaceMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSpaceServerResponseModel>> Create(
			ApiSpaceServerRequestModel model)
		{
			CreateResponse<ApiSpaceServerResponseModel> response = ValidationResponseFactory<ApiSpaceServerResponseModel>.CreateResponse(await this.SpaceModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolSpaceMapper.MapModelToBO(default(int), model);
				var record = await this.SpaceRepository.Create(this.DalSpaceMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSpaceMapper.MapBOToModel(this.DalSpaceMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSpaceServerResponseModel>> Update(
			int id,
			ApiSpaceServerRequestModel model)
		{
			var validationResult = await this.SpaceModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSpaceMapper.MapModelToBO(id, model);
				await this.SpaceRepository.Update(this.DalSpaceMapper.MapBOToEF(bo));

				var record = await this.SpaceRepository.Get(id);

				return ValidationResponseFactory<ApiSpaceServerResponseModel>.UpdateResponse(this.BolSpaceMapper.MapBOToModel(this.DalSpaceMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiSpaceServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SpaceModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.SpaceRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b0fbaf98ca7f5e660e29102eaa46c05c</Hash>
</Codenesium>*/