using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractSpaceSpaceFeatureService : AbstractService
	{
		protected ISpaceSpaceFeatureRepository SpaceSpaceFeatureRepository { get; private set; }

		protected IApiSpaceSpaceFeatureRequestModelValidator SpaceSpaceFeatureModelValidator { get; private set; }

		protected IBOLSpaceSpaceFeatureMapper BolSpaceSpaceFeatureMapper { get; private set; }

		protected IDALSpaceSpaceFeatureMapper DalSpaceSpaceFeatureMapper { get; private set; }

		private ILogger logger;

		public AbstractSpaceSpaceFeatureService(
			ILogger logger,
			ISpaceSpaceFeatureRepository spaceSpaceFeatureRepository,
			IApiSpaceSpaceFeatureRequestModelValidator spaceSpaceFeatureModelValidator,
			IBOLSpaceSpaceFeatureMapper bolSpaceSpaceFeatureMapper,
			IDALSpaceSpaceFeatureMapper dalSpaceSpaceFeatureMapper)
			: base()
		{
			this.SpaceSpaceFeatureRepository = spaceSpaceFeatureRepository;
			this.SpaceSpaceFeatureModelValidator = spaceSpaceFeatureModelValidator;
			this.BolSpaceSpaceFeatureMapper = bolSpaceSpaceFeatureMapper;
			this.DalSpaceSpaceFeatureMapper = dalSpaceSpaceFeatureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpaceSpaceFeatureResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SpaceSpaceFeatureRepository.All(limit, offset);

			return this.BolSpaceSpaceFeatureMapper.MapBOToModel(this.DalSpaceSpaceFeatureMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSpaceSpaceFeatureResponseModel> Get(int id)
		{
			var record = await this.SpaceSpaceFeatureRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSpaceSpaceFeatureMapper.MapBOToModel(this.DalSpaceSpaceFeatureMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSpaceSpaceFeatureResponseModel>> Create(
			ApiSpaceSpaceFeatureRequestModel model)
		{
			CreateResponse<ApiSpaceSpaceFeatureResponseModel> response = new CreateResponse<ApiSpaceSpaceFeatureResponseModel>(await this.SpaceSpaceFeatureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSpaceSpaceFeatureMapper.MapModelToBO(default(int), model);
				var record = await this.SpaceSpaceFeatureRepository.Create(this.DalSpaceSpaceFeatureMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSpaceSpaceFeatureMapper.MapBOToModel(this.DalSpaceSpaceFeatureMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSpaceSpaceFeatureResponseModel>> Update(
			int id,
			ApiSpaceSpaceFeatureRequestModel model)
		{
			var validationResult = await this.SpaceSpaceFeatureModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSpaceSpaceFeatureMapper.MapModelToBO(id, model);
				await this.SpaceSpaceFeatureRepository.Update(this.DalSpaceSpaceFeatureMapper.MapBOToEF(bo));

				var record = await this.SpaceSpaceFeatureRepository.Get(id);

				return new UpdateResponse<ApiSpaceSpaceFeatureResponseModel>(this.BolSpaceSpaceFeatureMapper.MapBOToModel(this.DalSpaceSpaceFeatureMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSpaceSpaceFeatureResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.SpaceSpaceFeatureModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.SpaceSpaceFeatureRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiSpaceSpaceFeatureResponseModel>> BySpaceFeatureId(int spaceFeatureId, int limit = 0, int offset = int.MaxValue)
		{
			List<SpaceSpaceFeature> records = await this.SpaceSpaceFeatureRepository.BySpaceFeatureId(spaceFeatureId, limit, offset);

			return this.BolSpaceSpaceFeatureMapper.MapBOToModel(this.DalSpaceSpaceFeatureMapper.MapEFToBO(records));
		}

		public async Task<List<ApiSpaceSpaceFeatureResponseModel>> BySpaceId(int spaceId, int limit = 0, int offset = int.MaxValue)
		{
			List<SpaceSpaceFeature> records = await this.SpaceSpaceFeatureRepository.BySpaceId(spaceId, limit, offset);

			return this.BolSpaceSpaceFeatureMapper.MapBOToModel(this.DalSpaceSpaceFeatureMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>3484d07ef8b50ca2ff7f24fc284d29e1</Hash>
</Codenesium>*/