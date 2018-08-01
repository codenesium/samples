using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBillOfMaterialService : AbstractService
	{
		private IBillOfMaterialRepository billOfMaterialRepository;

		private IApiBillOfMaterialRequestModelValidator billOfMaterialModelValidator;

		private IBOLBillOfMaterialMapper bolBillOfMaterialMapper;

		private IDALBillOfMaterialMapper dalBillOfMaterialMapper;

		private ILogger logger;

		public AbstractBillOfMaterialService(
			ILogger logger,
			IBillOfMaterialRepository billOfMaterialRepository,
			IApiBillOfMaterialRequestModelValidator billOfMaterialModelValidator,
			IBOLBillOfMaterialMapper bolBillOfMaterialMapper,
			IDALBillOfMaterialMapper dalBillOfMaterialMapper)
			: base()
		{
			this.billOfMaterialRepository = billOfMaterialRepository;
			this.billOfMaterialModelValidator = billOfMaterialModelValidator;
			this.bolBillOfMaterialMapper = bolBillOfMaterialMapper;
			this.dalBillOfMaterialMapper = dalBillOfMaterialMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBillOfMaterialResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.billOfMaterialRepository.All(limit, offset);

			return this.bolBillOfMaterialMapper.MapBOToModel(this.dalBillOfMaterialMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBillOfMaterialResponseModel> Get(int billOfMaterialsID)
		{
			var record = await this.billOfMaterialRepository.Get(billOfMaterialsID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolBillOfMaterialMapper.MapBOToModel(this.dalBillOfMaterialMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiBillOfMaterialResponseModel>> Create(
			ApiBillOfMaterialRequestModel model)
		{
			CreateResponse<ApiBillOfMaterialResponseModel> response = new CreateResponse<ApiBillOfMaterialResponseModel>(await this.billOfMaterialModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolBillOfMaterialMapper.MapModelToBO(default(int), model);
				var record = await this.billOfMaterialRepository.Create(this.dalBillOfMaterialMapper.MapBOToEF(bo));

				response.SetRecord(this.bolBillOfMaterialMapper.MapBOToModel(this.dalBillOfMaterialMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiBillOfMaterialResponseModel>> Update(
			int billOfMaterialsID,
			ApiBillOfMaterialRequestModel model)
		{
			var validationResult = await this.billOfMaterialModelValidator.ValidateUpdateAsync(billOfMaterialsID, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolBillOfMaterialMapper.MapModelToBO(billOfMaterialsID, model);
				await this.billOfMaterialRepository.Update(this.dalBillOfMaterialMapper.MapBOToEF(bo));

				var record = await this.billOfMaterialRepository.Get(billOfMaterialsID);

				return new UpdateResponse<ApiBillOfMaterialResponseModel>(this.bolBillOfMaterialMapper.MapBOToModel(this.dalBillOfMaterialMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiBillOfMaterialResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int billOfMaterialsID)
		{
			ActionResponse response = new ActionResponse(await this.billOfMaterialModelValidator.ValidateDeleteAsync(billOfMaterialsID));
			if (response.Success)
			{
				await this.billOfMaterialRepository.Delete(billOfMaterialsID);
			}

			return response;
		}

		public async Task<ApiBillOfMaterialResponseModel> ByProductAssemblyIDComponentIDStartDate(int? productAssemblyID, int componentID, DateTime startDate)
		{
			BillOfMaterial record = await this.billOfMaterialRepository.ByProductAssemblyIDComponentIDStartDate(productAssemblyID, componentID, startDate);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolBillOfMaterialMapper.MapBOToModel(this.dalBillOfMaterialMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiBillOfMaterialResponseModel>> ByUnitMeasureCode(string unitMeasureCode)
		{
			List<BillOfMaterial> records = await this.billOfMaterialRepository.ByUnitMeasureCode(unitMeasureCode);

			return this.bolBillOfMaterialMapper.MapBOToModel(this.dalBillOfMaterialMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>406fc0fbab9b1cd9c435f401df1ba6fd</Hash>
</Codenesium>*/