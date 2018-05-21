using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public abstract class AbstractBOPen: AbstractBOManager
	{
		private IPenRepository penRepository;
		private IApiPenModelValidator penModelValidator;
		private ILogger logger;

		public AbstractBOPen(
			ILogger logger,
			IPenRepository penRepository,
			IApiPenModelValidator penModelValidator)
			: base()

		{
			this.penRepository = penRepository;
			this.penModelValidator = penModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOPen>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.penRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOPen> Get(int id)
		{
			return this.penRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOPen>> Create(
			ApiPenModel model)
		{
			CreateResponse<POCOPen> response = new CreateResponse<POCOPen>(await this.penModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPen record = await this.penRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPenModel model)
		{
			ActionResponse response = new ActionResponse(await this.penModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.penRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.penModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.penRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>45068a725fabfe62e2b060c73221f3a6</Hash>
</Codenesium>*/