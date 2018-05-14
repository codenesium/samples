using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOClasp
	{
		private IClaspRepository claspRepository;
		private IClaspModelValidator claspModelValidator;
		private ILogger logger;

		public AbstractBOClasp(
			ILogger logger,
			IClaspRepository claspRepository,
			IClaspModelValidator claspModelValidator)

		{
			this.claspRepository = claspRepository;
			this.claspModelValidator = claspModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOClasp> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.claspRepository.All(skip, take, orderClause);
		}

		public virtual POCOClasp Get(int id)
		{
			return this.claspRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOClasp>> Create(
			ClaspModel model)
		{
			CreateResponse<POCOClasp> response = new CreateResponse<POCOClasp>(await this.claspModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOClasp record = this.claspRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ClaspModel model)
		{
			ActionResponse response = new ActionResponse(await this.claspModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.claspRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.claspModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.claspRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e93c8a1eca75b863af37069f6eb9e80b</Hash>
</Codenesium>*/