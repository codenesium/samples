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
	public abstract class AbstractBOSpaceXSpaceFeature
	{
		private ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository;
		private ISpaceXSpaceFeatureModelValidator spaceXSpaceFeatureModelValidator;
		private ILogger logger;

		public AbstractBOSpaceXSpaceFeature(
			ILogger logger,
			ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository,
			ISpaceXSpaceFeatureModelValidator spaceXSpaceFeatureModelValidator)

		{
			this.spaceXSpaceFeatureRepository = spaceXSpaceFeatureRepository;
			this.spaceXSpaceFeatureModelValidator = spaceXSpaceFeatureModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOSpaceXSpaceFeature> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.spaceXSpaceFeatureRepository.All(skip, take, orderClause);
		}

		public virtual POCOSpaceXSpaceFeature Get(int id)
		{
			return this.spaceXSpaceFeatureRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOSpaceXSpaceFeature>> Create(
			SpaceXSpaceFeatureModel model)
		{
			CreateResponse<POCOSpaceXSpaceFeature> response = new CreateResponse<POCOSpaceXSpaceFeature>(await this.spaceXSpaceFeatureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSpaceXSpaceFeature record = this.spaceXSpaceFeatureRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			SpaceXSpaceFeatureModel model)
		{
			ActionResponse response = new ActionResponse(await this.spaceXSpaceFeatureModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.spaceXSpaceFeatureRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.spaceXSpaceFeatureModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.spaceXSpaceFeatureRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b5587d96be9d04790ea43ee9696ec248</Hash>
</Codenesium>*/