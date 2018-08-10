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
	public abstract class AbstractSpaceFeatureService : AbstractService
	{
		protected ISpaceFeatureRepository SpaceFeatureRepository { get; private set; }

		protected IApiSpaceFeatureRequestModelValidator SpaceFeatureModelValidator { get; private set; }

		protected IBOLSpaceFeatureMapper BolSpaceFeatureMapper { get; private set; }

		protected IDALSpaceFeatureMapper DalSpaceFeatureMapper { get; private set; }

		protected IBOLSpaceXSpaceFeatureMapper BolSpaceXSpaceFeatureMapper { get; private set; }

		protected IDALSpaceXSpaceFeatureMapper DalSpaceXSpaceFeatureMapper { get; private set; }

		private ILogger logger;

		public AbstractSpaceFeatureService(
			ILogger logger,
			ISpaceFeatureRepository spaceFeatureRepository,
			IApiSpaceFeatureRequestModelValidator spaceFeatureModelValidator,
			IBOLSpaceFeatureMapper bolSpaceFeatureMapper,
			IDALSpaceFeatureMapper dalSpaceFeatureMapper,
			IBOLSpaceXSpaceFeatureMapper bolSpaceXSpaceFeatureMapper,
			IDALSpaceXSpaceFeatureMapper dalSpaceXSpaceFeatureMapper)
			: base()
		{
			this.SpaceFeatureRepository = spaceFeatureRepository;
			this.SpaceFeatureModelValidator = spaceFeatureModelValidator;
			this.BolSpaceFeatureMapper = bolSpaceFeatureMapper;
			this.DalSpaceFeatureMapper = dalSpaceFeatureMapper;
			this.BolSpaceXSpaceFeatureMapper = bolSpaceXSpaceFeatureMapper;
			this.DalSpaceXSpaceFeatureMapper = dalSpaceXSpaceFeatureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpaceFeatureResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SpaceFeatureRepository.All(limit, offset);

			return this.BolSpaceFeatureMapper.MapBOToModel(this.DalSpaceFeatureMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSpaceFeatureResponseModel> Get(int id)
		{
			var record = await this.SpaceFeatureRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSpaceFeatureMapper.MapBOToModel(this.DalSpaceFeatureMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSpaceFeatureResponseModel>> Create(
			ApiSpaceFeatureRequestModel model)
		{
			CreateResponse<ApiSpaceFeatureResponseModel> response = new CreateResponse<ApiSpaceFeatureResponseModel>(await this.SpaceFeatureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSpaceFeatureMapper.MapModelToBO(default(int), model);
				var record = await this.SpaceFeatureRepository.Create(this.DalSpaceFeatureMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSpaceFeatureMapper.MapBOToModel(this.DalSpaceFeatureMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSpaceFeatureResponseModel>> Update(
			int id,
			ApiSpaceFeatureRequestModel model)
		{
			var validationResult = await this.SpaceFeatureModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSpaceFeatureMapper.MapModelToBO(id, model);
				await this.SpaceFeatureRepository.Update(this.DalSpaceFeatureMapper.MapBOToEF(bo));

				var record = await this.SpaceFeatureRepository.Get(id);

				return new UpdateResponse<ApiSpaceFeatureResponseModel>(this.BolSpaceFeatureMapper.MapBOToModel(this.DalSpaceFeatureMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSpaceFeatureResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.SpaceFeatureModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.SpaceFeatureRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiSpaceXSpaceFeatureResponseModel>> SpaceXSpaceFeatures(int spaceFeatureId, int limit = int.MaxValue, int offset = 0)
		{
			List<SpaceXSpaceFeature> records = await this.SpaceFeatureRepository.SpaceXSpaceFeatures(spaceFeatureId, limit, offset);

			return this.BolSpaceXSpaceFeatureMapper.MapBOToModel(this.DalSpaceXSpaceFeatureMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>d4e20626157bde357b70e1aa7ab1abe1</Hash>
</Codenesium>*/