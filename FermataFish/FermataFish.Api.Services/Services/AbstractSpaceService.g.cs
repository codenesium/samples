using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractSpaceService : AbstractService
	{
		protected ISpaceRepository SpaceRepository { get; private set; }

		protected IApiSpaceRequestModelValidator SpaceModelValidator { get; private set; }

		protected IBOLSpaceMapper BolSpaceMapper { get; private set; }

		protected IDALSpaceMapper DalSpaceMapper { get; private set; }

		protected IBOLSpaceXSpaceFeatureMapper BolSpaceXSpaceFeatureMapper { get; private set; }

		protected IDALSpaceXSpaceFeatureMapper DalSpaceXSpaceFeatureMapper { get; private set; }

		private ILogger logger;

		public AbstractSpaceService(
			ILogger logger,
			ISpaceRepository spaceRepository,
			IApiSpaceRequestModelValidator spaceModelValidator,
			IBOLSpaceMapper bolSpaceMapper,
			IDALSpaceMapper dalSpaceMapper,
			IBOLSpaceXSpaceFeatureMapper bolSpaceXSpaceFeatureMapper,
			IDALSpaceXSpaceFeatureMapper dalSpaceXSpaceFeatureMapper)
			: base()
		{
			this.SpaceRepository = spaceRepository;
			this.SpaceModelValidator = spaceModelValidator;
			this.BolSpaceMapper = bolSpaceMapper;
			this.DalSpaceMapper = dalSpaceMapper;
			this.BolSpaceXSpaceFeatureMapper = bolSpaceXSpaceFeatureMapper;
			this.DalSpaceXSpaceFeatureMapper = dalSpaceXSpaceFeatureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpaceResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SpaceRepository.All(limit, offset);

			return this.BolSpaceMapper.MapBOToModel(this.DalSpaceMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSpaceResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiSpaceResponseModel>> Create(
			ApiSpaceRequestModel model)
		{
			CreateResponse<ApiSpaceResponseModel> response = new CreateResponse<ApiSpaceResponseModel>(await this.SpaceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSpaceMapper.MapModelToBO(default(int), model);
				var record = await this.SpaceRepository.Create(this.DalSpaceMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSpaceMapper.MapBOToModel(this.DalSpaceMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSpaceResponseModel>> Update(
			int id,
			ApiSpaceRequestModel model)
		{
			var validationResult = await this.SpaceModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSpaceMapper.MapModelToBO(id, model);
				await this.SpaceRepository.Update(this.DalSpaceMapper.MapBOToEF(bo));

				var record = await this.SpaceRepository.Get(id);

				return new UpdateResponse<ApiSpaceResponseModel>(this.BolSpaceMapper.MapBOToModel(this.DalSpaceMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSpaceResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.SpaceModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.SpaceRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatures(int spaceId, int limit = int.MaxValue, int offset = 0)
		{
			List<SpaceXSpaceFeature> records = await this.SpaceRepository.SpaceXSpaceFeatures(spaceId, limit, offset);

			return this.BolSpaceXSpaceFeatureMapper.MapBOToModel(this.DalSpaceXSpaceFeatureMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>7959eeda69a4b69596a9d7dc97ff073a</Hash>
</Codenesium>*/