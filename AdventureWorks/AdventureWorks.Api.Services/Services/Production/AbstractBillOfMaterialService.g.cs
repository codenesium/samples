using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBillOfMaterialService : AbstractService
	{
		protected IBillOfMaterialRepository BillOfMaterialRepository { get; private set; }

		protected IApiBillOfMaterialServerRequestModelValidator BillOfMaterialModelValidator { get; private set; }

		protected IBOLBillOfMaterialMapper BolBillOfMaterialMapper { get; private set; }

		protected IDALBillOfMaterialMapper DalBillOfMaterialMapper { get; private set; }

		private ILogger logger;

		public AbstractBillOfMaterialService(
			ILogger logger,
			IBillOfMaterialRepository billOfMaterialRepository,
			IApiBillOfMaterialServerRequestModelValidator billOfMaterialModelValidator,
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

		public virtual async Task<List<ApiBillOfMaterialServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.BillOfMaterialRepository.All(limit, offset);

			return this.BolBillOfMaterialMapper.MapBOToModel(this.DalBillOfMaterialMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBillOfMaterialServerResponseModel> Get(int billOfMaterialsID)
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

		public virtual async Task<CreateResponse<ApiBillOfMaterialServerResponseModel>> Create(
			ApiBillOfMaterialServerRequestModel model)
		{
			CreateResponse<ApiBillOfMaterialServerResponseModel> response = ValidationResponseFactory<ApiBillOfMaterialServerResponseModel>.CreateResponse(await this.BillOfMaterialModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolBillOfMaterialMapper.MapModelToBO(default(int), model);
				var record = await this.BillOfMaterialRepository.Create(this.DalBillOfMaterialMapper.MapBOToEF(bo));

				response.SetRecord(this.BolBillOfMaterialMapper.MapBOToModel(this.DalBillOfMaterialMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiBillOfMaterialServerResponseModel>> Update(
			int billOfMaterialsID,
			ApiBillOfMaterialServerRequestModel model)
		{
			var validationResult = await this.BillOfMaterialModelValidator.ValidateUpdateAsync(billOfMaterialsID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolBillOfMaterialMapper.MapModelToBO(billOfMaterialsID, model);
				await this.BillOfMaterialRepository.Update(this.DalBillOfMaterialMapper.MapBOToEF(bo));

				var record = await this.BillOfMaterialRepository.Get(billOfMaterialsID);

				return ValidationResponseFactory<ApiBillOfMaterialServerResponseModel>.UpdateResponse(this.BolBillOfMaterialMapper.MapBOToModel(this.DalBillOfMaterialMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiBillOfMaterialServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int billOfMaterialsID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.BillOfMaterialModelValidator.ValidateDeleteAsync(billOfMaterialsID));

			if (response.Success)
			{
				await this.BillOfMaterialRepository.Delete(billOfMaterialsID);
			}

			return response;
		}

		public async virtual Task<List<ApiBillOfMaterialServerResponseModel>> ByUnitMeasureCode(string unitMeasureCode, int limit = 0, int offset = int.MaxValue)
		{
			List<BillOfMaterial> records = await this.BillOfMaterialRepository.ByUnitMeasureCode(unitMeasureCode, limit, offset);

			return this.BolBillOfMaterialMapper.MapBOToModel(this.DalBillOfMaterialMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>d76d34f9fd200ee3df69dcdce00434b1</Hash>
</Codenesium>*/