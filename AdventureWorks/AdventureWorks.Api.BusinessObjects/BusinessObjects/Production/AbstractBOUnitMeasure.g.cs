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
	public abstract class AbstractBOUnitMeasure: AbstractBOManager
	{
		private IUnitMeasureRepository unitMeasureRepository;
		private IApiUnitMeasureRequestModelValidator unitMeasureModelValidator;
		private IBOLUnitMeasureMapper unitMeasureMapper;
		private ILogger logger;

		public AbstractBOUnitMeasure(
			ILogger logger,
			IUnitMeasureRepository unitMeasureRepository,
			IApiUnitMeasureRequestModelValidator unitMeasureModelValidator,
			IBOLUnitMeasureMapper unitMeasureMapper)
			: base()

		{
			this.unitMeasureRepository = unitMeasureRepository;
			this.unitMeasureModelValidator = unitMeasureModelValidator;
			this.unitMeasureMapper = unitMeasureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiUnitMeasureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.unitMeasureRepository.All(skip, take, orderClause);

			return this.unitMeasureMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiUnitMeasureResponseModel> Get(string unitMeasureCode)
		{
			var record = await unitMeasureRepository.Get(unitMeasureCode);

			return this.unitMeasureMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiUnitMeasureResponseModel>> Create(
			ApiUnitMeasureRequestModel model)
		{
			CreateResponse<ApiUnitMeasureResponseModel> response = new CreateResponse<ApiUnitMeasureResponseModel>(await this.unitMeasureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.unitMeasureMapper.MapModelToDTO(default (string), model);
				var record = await this.unitMeasureRepository.Create(dto);

				response.SetRecord(this.unitMeasureMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			string unitMeasureCode,
			ApiUnitMeasureRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.unitMeasureModelValidator.ValidateUpdateAsync(unitMeasureCode, model));

			if (response.Success)
			{
				var dto = this.unitMeasureMapper.MapModelToDTO(unitMeasureCode, model);
				await this.unitMeasureRepository.Update(unitMeasureCode, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			string unitMeasureCode)
		{
			ActionResponse response = new ActionResponse(await this.unitMeasureModelValidator.ValidateDeleteAsync(unitMeasureCode));

			if (response.Success)
			{
				await this.unitMeasureRepository.Delete(unitMeasureCode);
			}
			return response;
		}

		public async Task<ApiUnitMeasureResponseModel> GetName(string name)
		{
			DTOUnitMeasure record = await this.unitMeasureRepository.GetName(name);

			return this.unitMeasureMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>9cbdba96b1f277eeb47716918d3590d7</Hash>
</Codenesium>*/