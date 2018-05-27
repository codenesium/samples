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

namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOSpaceXSpaceFeature: AbstractBOManager
	{
		private ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository;
		private IApiSpaceXSpaceFeatureRequestModelValidator spaceXSpaceFeatureModelValidator;
		private IBOLSpaceXSpaceFeatureMapper spaceXSpaceFeatureMapper;
		private ILogger logger;

		public AbstractBOSpaceXSpaceFeature(
			ILogger logger,
			ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository,
			IApiSpaceXSpaceFeatureRequestModelValidator spaceXSpaceFeatureModelValidator,
			IBOLSpaceXSpaceFeatureMapper spaceXSpaceFeatureMapper)
			: base()

		{
			this.spaceXSpaceFeatureRepository = spaceXSpaceFeatureRepository;
			this.spaceXSpaceFeatureModelValidator = spaceXSpaceFeatureModelValidator;
			this.spaceXSpaceFeatureMapper = spaceXSpaceFeatureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpaceXSpaceFeatureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.spaceXSpaceFeatureRepository.All(skip, take, orderClause);

			return this.spaceXSpaceFeatureMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiSpaceXSpaceFeatureResponseModel> Get(int id)
		{
			var record = await spaceXSpaceFeatureRepository.Get(id);

			return this.spaceXSpaceFeatureMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiSpaceXSpaceFeatureResponseModel>> Create(
			ApiSpaceXSpaceFeatureRequestModel model)
		{
			CreateResponse<ApiSpaceXSpaceFeatureResponseModel> response = new CreateResponse<ApiSpaceXSpaceFeatureResponseModel>(await this.spaceXSpaceFeatureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.spaceXSpaceFeatureMapper.MapModelToDTO(default (int), model);
				var record = await this.spaceXSpaceFeatureRepository.Create(dto);

				response.SetRecord(this.spaceXSpaceFeatureMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiSpaceXSpaceFeatureRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.spaceXSpaceFeatureModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.spaceXSpaceFeatureMapper.MapModelToDTO(id, model);
				await this.spaceXSpaceFeatureRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.spaceXSpaceFeatureModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.spaceXSpaceFeatureRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9efa67fd92d3b54129e16636ba6e5231</Hash>
</Codenesium>*/