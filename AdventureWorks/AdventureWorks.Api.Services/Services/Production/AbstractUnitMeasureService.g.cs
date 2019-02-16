using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractUnitMeasureService : AbstractService
	{
		private IMediator mediator;

		protected IUnitMeasureRepository UnitMeasureRepository { get; private set; }

		protected IApiUnitMeasureServerRequestModelValidator UnitMeasureModelValidator { get; private set; }

		protected IDALUnitMeasureMapper DalUnitMeasureMapper { get; private set; }

		protected IDALBillOfMaterialMapper DalBillOfMaterialMapper { get; private set; }

		protected IDALProductMapper DalProductMapper { get; private set; }

		private ILogger logger;

		public AbstractUnitMeasureService(
			ILogger logger,
			IMediator mediator,
			IUnitMeasureRepository unitMeasureRepository,
			IApiUnitMeasureServerRequestModelValidator unitMeasureModelValidator,
			IDALUnitMeasureMapper dalUnitMeasureMapper,
			IDALBillOfMaterialMapper dalBillOfMaterialMapper,
			IDALProductMapper dalProductMapper)
			: base()
		{
			this.UnitMeasureRepository = unitMeasureRepository;
			this.UnitMeasureModelValidator = unitMeasureModelValidator;
			this.DalUnitMeasureMapper = dalUnitMeasureMapper;
			this.DalBillOfMaterialMapper = dalBillOfMaterialMapper;
			this.DalProductMapper = dalProductMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiUnitMeasureServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			var records = await this.UnitMeasureRepository.All(limit, offset, query);

			return this.DalUnitMeasureMapper.MapBOToModel(records);
		}

		public virtual async Task<ApiUnitMeasureServerResponseModel> Get(string unitMeasureCode)
		{
			var record = await this.UnitMeasureRepository.Get(unitMeasureCode);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalUnitMeasureMapper.MapBOToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiUnitMeasureServerResponseModel>> Create(
			ApiUnitMeasureServerRequestModel model)
		{
			CreateResponse<ApiUnitMeasureServerResponseModel> response = ValidationResponseFactory<ApiUnitMeasureServerResponseModel>.CreateResponse(await this.UnitMeasureModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.DalUnitMeasureMapper.MapModelToBO(default(string), model);
				var record = await this.UnitMeasureRepository.Create(bo);

				response.SetRecord(this.DalUnitMeasureMapper.MapBOToModel(record));
				await this.mediator.Publish(new UnitMeasureCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiUnitMeasureServerResponseModel>> Update(
			string unitMeasureCode,
			ApiUnitMeasureServerRequestModel model)
		{
			var validationResult = await this.UnitMeasureModelValidator.ValidateUpdateAsync(unitMeasureCode, model);

			if (validationResult.IsValid)
			{
				var bo = this.DalUnitMeasureMapper.MapModelToBO(unitMeasureCode, model);
				await this.UnitMeasureRepository.Update(bo);

				var record = await this.UnitMeasureRepository.Get(unitMeasureCode);

				var apiModel = this.DalUnitMeasureMapper.MapBOToModel(record);
				await this.mediator.Publish(new UnitMeasureUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiUnitMeasureServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiUnitMeasureServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string unitMeasureCode)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.UnitMeasureModelValidator.ValidateDeleteAsync(unitMeasureCode));

			if (response.Success)
			{
				await this.UnitMeasureRepository.Delete(unitMeasureCode);

				await this.mediator.Publish(new UnitMeasureDeletedNotification(unitMeasureCode));
			}

			return response;
		}

		public async virtual Task<ApiUnitMeasureServerResponseModel> ByName(string name)
		{
			UnitMeasure record = await this.UnitMeasureRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalUnitMeasureMapper.MapBOToModel(record);
			}
		}

		public async virtual Task<List<ApiBillOfMaterialServerResponseModel>> BillOfMaterialsByUnitMeasureCode(string unitMeasureCode, int limit = int.MaxValue, int offset = 0)
		{
			List<BillOfMaterial> records = await this.UnitMeasureRepository.BillOfMaterialsByUnitMeasureCode(unitMeasureCode, limit, offset);

			return this.DalBillOfMaterialMapper.MapBOToModel(records);
		}

		public async virtual Task<List<ApiProductServerResponseModel>> ProductsBySizeUnitMeasureCode(string sizeUnitMeasureCode, int limit = int.MaxValue, int offset = 0)
		{
			List<Product> records = await this.UnitMeasureRepository.ProductsBySizeUnitMeasureCode(sizeUnitMeasureCode, limit, offset);

			return this.DalProductMapper.MapBOToModel(records);
		}

		public async virtual Task<List<ApiProductServerResponseModel>> ProductsByWeightUnitMeasureCode(string weightUnitMeasureCode, int limit = int.MaxValue, int offset = 0)
		{
			List<Product> records = await this.UnitMeasureRepository.ProductsByWeightUnitMeasureCode(weightUnitMeasureCode, limit, offset);

			return this.DalProductMapper.MapBOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>e6f51da531cf3a19eab7ff62477cc759</Hash>
</Codenesium>*/