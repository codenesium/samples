using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOStateProvince
	{
		private IStateProvinceRepository stateProvinceRepository;
		private IStateProvinceModelValidator stateProvinceModelValidator;
		private ILogger logger;

		public AbstractBOStateProvince(
			ILogger logger,
			IStateProvinceRepository stateProvinceRepository,
			IStateProvinceModelValidator stateProvinceModelValidator)

		{
			this.stateProvinceRepository = stateProvinceRepository;
			this.stateProvinceModelValidator = stateProvinceModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			StateProvinceModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.stateProvinceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.stateProvinceRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int stateProvinceID,
			StateProvinceModel model)
		{
			ActionResponse response = new ActionResponse(await this.stateProvinceModelValidator.ValidateUpdateAsync(stateProvinceID, model));

			if (response.Success)
			{
				this.stateProvinceRepository.Update(stateProvinceID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int stateProvinceID)
		{
			ActionResponse response = new ActionResponse(await this.stateProvinceModelValidator.ValidateDeleteAsync(stateProvinceID));

			if (response.Success)
			{
				this.stateProvinceRepository.Delete(stateProvinceID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int stateProvinceID)
		{
			return this.stateProvinceRepository.GetById(stateProvinceID);
		}

		public virtual POCOStateProvince GetByIdDirect(int stateProvinceID)
		{
			return this.stateProvinceRepository.GetByIdDirect(stateProvinceID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFStateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.stateProvinceRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.stateProvinceRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOStateProvince> GetWhereDirect(Expression<Func<EFStateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.stateProvinceRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>5e5f9ce87cac269873d187499cb45375</Hash>
</Codenesium>*/