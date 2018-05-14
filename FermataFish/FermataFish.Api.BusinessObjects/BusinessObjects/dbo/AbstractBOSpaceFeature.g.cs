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
	public abstract class AbstractBOSpaceFeature
	{
		private ISpaceFeatureRepository spaceFeatureRepository;
		private IApiSpaceFeatureModelValidator spaceFeatureModelValidator;
		private ILogger logger;

		public AbstractBOSpaceFeature(
			ILogger logger,
			ISpaceFeatureRepository spaceFeatureRepository,
			IApiSpaceFeatureModelValidator spaceFeatureModelValidator)

		{
			this.spaceFeatureRepository = spaceFeatureRepository;
			this.spaceFeatureModelValidator = spaceFeatureModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOSpaceFeature> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.spaceFeatureRepository.All(skip, take, orderClause);
		}

		public virtual POCOSpaceFeature Get(int id)
		{
			return this.spaceFeatureRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOSpaceFeature>> Create(
			ApiSpaceFeatureModel model)
		{
			CreateResponse<POCOSpaceFeature> response = new CreateResponse<POCOSpaceFeature>(await this.spaceFeatureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSpaceFeature record = this.spaceFeatureRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiSpaceFeatureModel model)
		{
			ActionResponse response = new ActionResponse(await this.spaceFeatureModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.spaceFeatureRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.spaceFeatureModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.spaceFeatureRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d40c40e8e3dd045285625db9eebb56ca</Hash>
</Codenesium>*/