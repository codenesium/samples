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
	public abstract class AbstractBOSpaceFeature: AbstractBOManager
	{
		private ISpaceFeatureRepository spaceFeatureRepository;
		private IApiSpaceFeatureRequestModelValidator spaceFeatureModelValidator;
		private IBOLSpaceFeatureMapper spaceFeatureMapper;
		private ILogger logger;

		public AbstractBOSpaceFeature(
			ILogger logger,
			ISpaceFeatureRepository spaceFeatureRepository,
			IApiSpaceFeatureRequestModelValidator spaceFeatureModelValidator,
			IBOLSpaceFeatureMapper spaceFeatureMapper)
			: base()

		{
			this.spaceFeatureRepository = spaceFeatureRepository;
			this.spaceFeatureModelValidator = spaceFeatureModelValidator;
			this.spaceFeatureMapper = spaceFeatureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpaceFeatureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.spaceFeatureRepository.All(skip, take, orderClause);

			return this.spaceFeatureMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiSpaceFeatureResponseModel> Get(int id)
		{
			var record = await spaceFeatureRepository.Get(id);

			return this.spaceFeatureMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiSpaceFeatureResponseModel>> Create(
			ApiSpaceFeatureRequestModel model)
		{
			CreateResponse<ApiSpaceFeatureResponseModel> response = new CreateResponse<ApiSpaceFeatureResponseModel>(await this.spaceFeatureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.spaceFeatureMapper.MapModelToDTO(default (int), model);
				var record = await this.spaceFeatureRepository.Create(dto);

				response.SetRecord(this.spaceFeatureMapper.MapDTOToModel(record));
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
				var dto = this.spaceFeatureMapper.MapModelToDTO(id, model);
				await this.spaceFeatureRepository.Update(id, dto);
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
    <Hash>ae19397fed24aa5d10f230b747169c91</Hash>
</Codenesium>*/