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
	public abstract class AbstractBOPen
	{
		private IPenRepository penRepository;
		private IPenModelValidator penModelValidator;
		private ILogger logger;

		public AbstractBOPen(
			ILogger logger,
			IPenRepository penRepository,
			IPenModelValidator penModelValidator)

		{
			this.penRepository = penRepository;
			this.penModelValidator = penModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			PenModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.penModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.penRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			PenModel model)
		{
			ActionResponse response = new ActionResponse(await this.penModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.penRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.penModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.penRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOPen Get(int id)
		{
			return this.penRepository.Get(id);
		}

		public virtual List<POCOPen> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.penRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>6bb05df1a732c9e7b735403665dae495</Hash>
</Codenesium>*/