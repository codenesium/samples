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
		private ISpaceFeatureModelValidator spaceFeatureModelValidator;
		private ILogger logger;

		public AbstractBOSpaceFeature(
			ILogger logger,
			ISpaceFeatureRepository spaceFeatureRepository,
			ISpaceFeatureModelValidator spaceFeatureModelValidator)

		{
			this.spaceFeatureRepository = spaceFeatureRepository;
			this.spaceFeatureModelValidator = spaceFeatureModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			SpaceFeatureModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.spaceFeatureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.spaceFeatureRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			SpaceFeatureModel model)
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

		public virtual ApiResponse GetById(int id)
		{
			return this.spaceFeatureRepository.GetById(id);
		}

		public virtual POCOSpaceFeature GetByIdDirect(int id)
		{
			return this.spaceFeatureRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.spaceFeatureRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.spaceFeatureRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSpaceFeature> GetWhereDirect(Expression<Func<EFSpaceFeature, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.spaceFeatureRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>d723514ceda7880c47194ee1599505cc</Hash>
</Codenesium>*/