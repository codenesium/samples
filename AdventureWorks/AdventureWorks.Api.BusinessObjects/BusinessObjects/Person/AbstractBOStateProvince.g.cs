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
		private IApiStateProvinceModelValidator stateProvinceModelValidator;
		private ILogger logger;

		public AbstractBOStateProvince(
			ILogger logger,
			IStateProvinceRepository stateProvinceRepository,
			IApiStateProvinceModelValidator stateProvinceModelValidator)

		{
			this.stateProvinceRepository = stateProvinceRepository;
			this.stateProvinceModelValidator = stateProvinceModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOStateProvince> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.stateProvinceRepository.All(skip, take, orderClause);
		}

		public virtual POCOStateProvince Get(int stateProvinceID)
		{
			return this.stateProvinceRepository.Get(stateProvinceID);
		}

		public virtual async Task<CreateResponse<POCOStateProvince>> Create(
			ApiStateProvinceModel model)
		{
			CreateResponse<POCOStateProvince> response = new CreateResponse<POCOStateProvince>(await this.stateProvinceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOStateProvince record = this.stateProvinceRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int stateProvinceID,
			ApiStateProvinceModel model)
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

		public POCOStateProvince GetName(string name)
		{
			return this.stateProvinceRepository.GetName(name);
		}

		public POCOStateProvince GetStateProvinceCodeCountryRegionCode(string stateProvinceCode,string countryRegionCode)
		{
			return this.stateProvinceRepository.GetStateProvinceCodeCountryRegionCode(stateProvinceCode,countryRegionCode);
		}
	}
}

/*<Codenesium>
    <Hash>cb697dc948b6b62a80d3acbb55a06d04</Hash>
</Codenesium>*/