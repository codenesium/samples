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
	public abstract class AbstractBOSpace: AbstractBOManager
	{
		private ISpaceRepository spaceRepository;
		private IApiSpaceModelValidator spaceModelValidator;
		private ILogger logger;

		public AbstractBOSpace(
			ILogger logger,
			ISpaceRepository spaceRepository,
			IApiSpaceModelValidator spaceModelValidator)
			: base()

		{
			this.spaceRepository = spaceRepository;
			this.spaceModelValidator = spaceModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOSpace>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.spaceRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOSpace> Get(int id)
		{
			return this.spaceRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOSpace>> Create(
			ApiSpaceModel model)
		{
			CreateResponse<POCOSpace> response = new CreateResponse<POCOSpace>(await this.spaceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSpace record = await this.spaceRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiSpaceModel model)
		{
			ActionResponse response = new ActionResponse(await this.spaceModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.spaceRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.spaceModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.spaceRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>47af12b4ac2d0c1adadcc3454000cb2a</Hash>
</Codenesium>*/