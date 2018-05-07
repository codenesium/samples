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
	public abstract class AbstractBOSpace
	{
		private ISpaceRepository spaceRepository;
		private ISpaceModelValidator spaceModelValidator;
		private ILogger logger;

		public AbstractBOSpace(
			ILogger logger,
			ISpaceRepository spaceRepository,
			ISpaceModelValidator spaceModelValidator)

		{
			this.spaceRepository = spaceRepository;
			this.spaceModelValidator = spaceModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			SpaceModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.spaceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.spaceRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			SpaceModel model)
		{
			ActionResponse response = new ActionResponse(await this.spaceModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.spaceRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.spaceModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.spaceRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOSpace Get(int id)
		{
			return this.spaceRepository.Get(id);
		}

		public virtual List<POCOSpace> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.spaceRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>6b3c0ff8ce1d6270dfbc8501bede9c8c</Hash>
</Codenesium>*/