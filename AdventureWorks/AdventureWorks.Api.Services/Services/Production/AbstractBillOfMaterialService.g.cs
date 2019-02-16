using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBillOfMaterialService : AbstractService
	{
		private IMediator mediator;

		protected IBillOfMaterialRepository BillOfMaterialRepository { get; private set; }

		protected IApiBillOfMaterialServerRequestModelValidator BillOfMaterialModelValidator { get; private set; }

		protected IDALBillOfMaterialMapper DalBillOfMaterialMapper { get; private set; }

		private ILogger logger;

		public AbstractBillOfMaterialService(
			ILogger logger,
			IMediator mediator,
			IBillOfMaterialRepository billOfMaterialRepository,
			IApiBillOfMaterialServerRequestModelValidator billOfMaterialModelValidator,
			IDALBillOfMaterialMapper dalBillOfMaterialMapper)
			: base()
		{
			this.BillOfMaterialRepository = billOfMaterialRepository;
			this.BillOfMaterialModelValidator = billOfMaterialModelValidator;
			this.DalBillOfMaterialMapper = dalBillOfMaterialMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiBillOfMaterialServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.BillOfMaterialRepository.All(limit, offset, query);

			return this.DalBillOfMaterialMapper.MapBOToModel(records);
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
				return this.DalBillOfMaterialMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiBillOfMaterialServerResponseModel>> Create(
			ApiBillOfMaterialServerRequestModel model)
		{
			CreateResponse<ApiBillOfMaterialServerResponseModel> response = ValidationResponseFactory<ApiBillOfMaterialServerResponseModel>.CreateResponse(await this.BillOfMaterialModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalBillOfMaterialMapper.MapModelToBO(default(int), model);
				var record = await this.BillOfMaterialRepository.Create(bo);

				response.SetRecord(this.DalBillOfMaterialMapper.MapBOToModel(record));
				await this.mediator.Publish(new BillOfMaterialCreatedNotification(response.Record));
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
				var bo = this.DalBillOfMaterialMapper.MapModelToBO(billOfMaterialsID, model);
				await this.BillOfMaterialRepository.Update(bo);

				var record = await this.BillOfMaterialRepository.Get(billOfMaterialsID);

				var apiModel = this.DalBillOfMaterialMapper.MapBOToModel(record);
				await this.mediator.Publish(new BillOfMaterialUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiBillOfMaterialServerResponseModel>.UpdateResponse(apiModel);
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

				await this.mediator.Publish(new BillOfMaterialDeletedNotification(billOfMaterialsID));
			}

			return response;
		}

		public async virtual Task<List<ApiBillOfMaterialServerResponseModel>> ByUnitMeasureCode(string unitMeasureCode, int limit = 0, int offset = int.MaxValue)
		{
			List<BillOfMaterial> records = await this.BillOfMaterialRepository.ByUnitMeasureCode(unitMeasureCode, limit, offset);

			return this.DalBillOfMaterialMapper.MapBOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>400182300c89492afa029bfcf06f7f65</Hash>
</Codenesium>*/