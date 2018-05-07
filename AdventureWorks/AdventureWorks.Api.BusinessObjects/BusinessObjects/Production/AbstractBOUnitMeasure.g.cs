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
	public abstract class AbstractBOUnitMeasure
	{
		private IUnitMeasureRepository unitMeasureRepository;
		private IUnitMeasureModelValidator unitMeasureModelValidator;
		private ILogger logger;

		public AbstractBOUnitMeasure(
			ILogger logger,
			IUnitMeasureRepository unitMeasureRepository,
			IUnitMeasureModelValidator unitMeasureModelValidator)

		{
			this.unitMeasureRepository = unitMeasureRepository;
			this.unitMeasureModelValidator = unitMeasureModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<string>> Create(
			UnitMeasureModel model)
		{
			CreateResponse<string> response = new CreateResponse<string>(await this.unitMeasureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				string id = this.unitMeasureRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			string unitMeasureCode,
			UnitMeasureModel model)
		{
			ActionResponse response = new ActionResponse(await this.unitMeasureModelValidator.ValidateUpdateAsync(unitMeasureCode, model));

			if (response.Success)
			{
				this.unitMeasureRepository.Update(unitMeasureCode, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			string unitMeasureCode)
		{
			ActionResponse response = new ActionResponse(await this.unitMeasureModelValidator.ValidateDeleteAsync(unitMeasureCode));

			if (response.Success)
			{
				this.unitMeasureRepository.Delete(unitMeasureCode);
			}
			return response;
		}

		public virtual POCOUnitMeasure Get(string unitMeasureCode)
		{
			return this.unitMeasureRepository.Get(unitMeasureCode);
		}

		public virtual List<POCOUnitMeasure> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.unitMeasureRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>651049f4918889cc2b4f953cd3612123</Hash>
</Codenesium>*/