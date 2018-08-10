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
		protected IBillOfMaterialRepository BillOfMaterialRepository { get; private set; }

		protected IApiBillOfMaterialRequestModelValidator BillOfMaterialModelValidator { get; private set; }

		protected IBOLBillOfMaterialMapper BolBillOfMaterialMapper { get; private set; }

		protected IDALBillOfMaterialMapper DalBillOfMaterialMapper { get; private set; }

		private ILogger logger;

		public AbstractBillOfMaterialService(
			ILogger logger,
			IBillOfMaterialRepository billOfMaterialRepository,
			IApiBillOfMaterialRequestModelValidator billOfMaterialModelValidator,
			IBOLBillOfMaterialMapper bolBillOfMaterialMapper,
			IDALBillOfMaterialMapper dalBillOfMaterialMapper)
			: base()
		{
			this.BillOfMaterialRepository = billOfMaterialRepository;
			this.BillOfMaterialModelValidator = billOfMaterialModelValidator;
			this.BolBillOfMaterialMapper = bolBillOfMaterialMapper;
			this.DalBillOfMaterialMapper = dalBillOfMaterialMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBillOfMaterialResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.BillOfMaterialRepository.All(limit, offset);

			return this.BolBillOfMaterialMapper.MapBOToModel(this.DalBillOfMaterialMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBillOfMaterialResponseModel> Get(int billOfMaterialsID)
		{
			var record = await this.BillOfMaterialRepository.Get(billOfMaterialsID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolBillOfMaterialMapper.MapBOToModel(this.DalBillOfMaterialMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiBillOfMaterialResponseModel>> Create(
			ApiBillOfMaterialRequestModel model)
		{
			CreateResponse<ApiBillOfMaterialResponseModel> response = new CreateResponse<ApiBillOfMaterialResponseModel>(await this.BillOfMaterialModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolBillOfMaterialMapper.MapModelToBO(default(int), model);
				var record = await this.BillOfMaterialRepository.Create(this.DalBillOfMaterialMapper.MapBOToEF(bo));

				response.SetRecord(this.BolBillOfMaterialMapper.MapBOToModel(this.DalBillOfMaterialMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiBillOfMaterialResponseModel>> Update(
			int billOfMaterialsID,
			ApiBillOfMaterialRequestModel model)
		{
			var validationResult = await this.BillOfMaterialModelValidator.ValidateUpdateAsync(billOfMaterialsID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolBillOfMaterialMapper.MapModelToBO(billOfMaterialsID, model);
				await this.BillOfMaterialRepository.Update(this.DalBillOfMaterialMapper.MapBOToEF(bo));

				var record = await this.BillOfMaterialRepository.Get(billOfMaterialsID);

				return new UpdateResponse<ApiBillOfMaterialResponseModel>(this.BolBillOfMaterialMapper.MapBOToModel(this.DalBillOfMaterialMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiBillOfMaterialResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int billOfMaterialsID)
		{
			ActionResponse response = new ActionResponse(await this.BillOfMaterialModelValidator.ValidateDeleteAsync(billOfMaterialsID));
			if (response.Success)
			{
				await this.BillOfMaterialRepository.Delete(billOfMaterialsID);
			}

			return response;
		}

		public async Task<ApiBillOfMaterialResponseModel> ByProductAssemblyIDComponentIDStartDate(int? productAssemblyID, int componentID, DateTime startDate)
		{
			BillOfMaterial record = await this.BillOfMaterialRepository.ByProductAssemblyIDComponentIDStartDate(productAssemblyID, componentID, startDate);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolBillOfMaterialMapper.MapBOToModel(this.DalBillOfMaterialMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiBillOfMaterialResponseModel>> ByUnitMeasureCode(string unitMeasureCode)
		{
			List<BillOfMaterial> records = await this.BillOfMaterialRepository.ByUnitMeasureCode(unitMeasureCode);

			return this.BolBillOfMaterialMapper.MapBOToModel(this.DalBillOfMaterialMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>148ed5d3d5bd019784e0aaa839a1bf74</Hash>
</Codenesium>*/