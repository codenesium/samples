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
	public abstract class AbstractSpaceXSpaceFeatureService : AbstractService
	{
		protected ISpaceXSpaceFeatureRepository SpaceXSpaceFeatureRepository { get; private set; }

		protected IApiSpaceXSpaceFeatureRequestModelValidator SpaceXSpaceFeatureModelValidator { get; private set; }

		protected IBOLSpaceXSpaceFeatureMapper BolSpaceXSpaceFeatureMapper { get; private set; }

		protected IDALSpaceXSpaceFeatureMapper DalSpaceXSpaceFeatureMapper { get; private set; }

		private ILogger logger;

		public AbstractSpaceXSpaceFeatureService(
			ILogger logger,
			ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository,
			IApiSpaceXSpaceFeatureRequestModelValidator spaceXSpaceFeatureModelValidator,
			IBOLSpaceXSpaceFeatureMapper bolSpaceXSpaceFeatureMapper,
			IDALSpaceXSpaceFeatureMapper dalSpaceXSpaceFeatureMapper)
			: base()
		{
			this.SpaceXSpaceFeatureRepository = spaceXSpaceFeatureRepository;
			this.SpaceXSpaceFeatureModelValidator = spaceXSpaceFeatureModelValidator;
			this.BolSpaceXSpaceFeatureMapper = bolSpaceXSpaceFeatureMapper;
			this.DalSpaceXSpaceFeatureMapper = dalSpaceXSpaceFeatureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpaceXSpaceFeatureResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SpaceXSpaceFeatureRepository.All(limit, offset);

			return this.BolSpaceXSpaceFeatureMapper.MapBOToModel(this.DalSpaceXSpaceFeatureMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSpaceXSpaceFeatureResponseModel> Get(int id)
		{
			var record = await this.SpaceXSpaceFeatureRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSpaceXSpaceFeatureMapper.MapBOToModel(this.DalSpaceXSpaceFeatureMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSpaceXSpaceFeatureResponseModel>> Create(
			ApiSpaceXSpaceFeatureRequestModel model)
		{
			CreateResponse<ApiSpaceXSpaceFeatureResponseModel> response = new CreateResponse<ApiSpaceXSpaceFeatureResponseModel>(await this.SpaceXSpaceFeatureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSpaceXSpaceFeatureMapper.MapModelToBO(default(int), model);
				var record = await this.SpaceXSpaceFeatureRepository.Create(this.DalSpaceXSpaceFeatureMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSpaceXSpaceFeatureMapper.MapBOToModel(this.DalSpaceXSpaceFeatureMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>> Update(
			int id,
			ApiSpaceXSpaceFeatureRequestModel model)
		{
			var validationResult = await this.SpaceXSpaceFeatureModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSpaceXSpaceFeatureMapper.MapModelToBO(id, model);
				await this.SpaceXSpaceFeatureRepository.Update(this.DalSpaceXSpaceFeatureMapper.MapBOToEF(bo));

				var record = await this.SpaceXSpaceFeatureRepository.Get(id);

				return new UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>(this.BolSpaceXSpaceFeatureMapper.MapBOToModel(this.DalSpaceXSpaceFeatureMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSpaceXSpaceFeatureResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.SpaceXSpaceFeatureModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.SpaceXSpaceFeatureRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c73dcb4c14666adeaa3a653100fa870a</Hash>
</Codenesium>*/