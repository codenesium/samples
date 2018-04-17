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

		public virtual async Task<CreateResponse<int>> Create(
			SpaceXSpaceFeatureModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.spaceXSpaceFeatureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.spaceXSpaceFeatureRepository.Create(model);
				response.SetId(id);
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

		public virtual ApiResponse GetById(int id)
		{
			return this.spaceXSpaceFeatureRepository.GetById(id);
		}

		public virtual POCOSpaceXSpaceFeature GetByIdDirect(int id)
		{
			return this.spaceXSpaceFeatureRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.spaceXSpaceFeatureRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.spaceXSpaceFeatureRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSpaceXSpaceFeature> GetWhereDirect(Expression<Func<EFSpaceXSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.spaceXSpaceFeatureRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>d86ea3a1bac00bf77b35fabc4e97e5e1</Hash>
</Codenesium>*/