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
	public abstract class AbstractBOState: AbstractBOManager
	{
		private IStateRepository stateRepository;
		private IApiStateModelValidator stateModelValidator;
		private ILogger logger;

		public AbstractBOState(
			ILogger logger,
			IStateRepository stateRepository,
			IApiStateModelValidator stateModelValidator)
			: base()

		{
			this.stateRepository = stateRepository;
			this.stateModelValidator = stateModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOState>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.stateRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOState> Get(int id)
		{
			return this.stateRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOState>> Create(
			ApiStateModel model)
		{
			CreateResponse<POCOState> response = new CreateResponse<POCOState>(await this.stateModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOState record = await this.stateRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiStateModel model)
		{
			ActionResponse response = new ActionResponse(await this.stateModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.stateRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.stateModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.stateRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>013eb2ccd2a5764c8f0984c2e6994552</Hash>
</Codenesium>*/