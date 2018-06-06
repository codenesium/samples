using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractSpaceFeatureService: AbstractService
	{
		private ISpaceFeatureRepository spaceFeatureRepository;
		private IApiSpaceFeatureRequestModelValidator spaceFeatureModelValidator;
		private IBOLSpaceFeatureMapper bolSpaceFeatureMapper;
		private IDALSpaceFeatureMapper dalSpaceFeatureMapper;
		private ILogger logger;

		public AbstractSpaceFeatureService(
			ILogger logger,
			ISpaceFeatureRepository spaceFeatureRepository,
			IApiSpaceFeatureRequestModelValidator spaceFeatureModelValidator,
			IBOLSpaceFeatureMapper bolspaceFeatureMapper,
			IDALSpaceFeatureMapper dalspaceFeatureMapper)
			: base()

		{
			this.spaceFeatureRepository = spaceFeatureRepository;
			this.spaceFeatureModelValidator = spaceFeatureModelValidator;
			this.bolSpaceFeatureMapper = bolspaceFeatureMapper;
			this.dalSpaceFeatureMapper = dalspaceFeatureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpaceFeatureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.spaceFeatureRepository.All(skip, take, orderClause);

			return this.bolSpaceFeatureMapper.MapBOToModel(this.dalSpaceFeatureMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSpaceFeatureResponseModel> Get(int id)
		{
			var record = await spaceFeatureRepository.Get(id);

			return this.bolSpaceFeatureMapper.MapBOToModel(this.dalSpaceFeatureMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiSpaceFeatureResponseModel>> Create(
			ApiSpaceFeatureRequestModel model)
		{
			CreateResponse<ApiSpaceFeatureResponseModel> response = new CreateResponse<ApiSpaceFeatureResponseModel>(await this.spaceFeatureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolSpaceFeatureMapper.MapModelToBO(default (int), model);
				var record = await this.spaceFeatureRepository.Create(this.dalSpaceFeatureMapper.MapBOToEF(bo));

				response.SetRecord(this.bolSpaceFeatureMapper.MapBOToModel(this.dalSpaceFeatureMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiSpaceFeatureRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.spaceFeatureModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.bolSpaceFeatureMapper.MapModelToBO(id, model);
				await this.spaceFeatureRepository.Update(this.dalSpaceFeatureMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.spaceFeatureModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.spaceFeatureRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b8c6332b52edc8a4a872454abf9ca2ec</Hash>
</Codenesium>*/