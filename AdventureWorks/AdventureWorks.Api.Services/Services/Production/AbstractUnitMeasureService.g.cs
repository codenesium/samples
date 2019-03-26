using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractUnitMeasureService : AbstractService
	{
		private MediatR.IMediator mediator;

		protected IUnitMeasureRepository UnitMeasureRepository { get; private set; }

		protected IApiUnitMeasureServerRequestModelValidator UnitMeasureModelValidator { get; private set; }

		protected IDALUnitMeasureMapper DalUnitMeasureMapper { get; private set; }

		protected IDALBillOfMaterialMapper DalBillOfMaterialMapper { get; private set; }

		protected IDALProductMapper DalProductMapper { get; private set; }

		private ILogger logger;

		public AbstractUnitMeasureService(
			ILogger logger,
			MediatR.IMediator mediator,
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
			List<UnitMeasure> records = await this.UnitMeasureRepository.All(limit, offset, query);

			return this.DalUnitMeasureMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiUnitMeasureServerResponseModel> Get(string unitMeasureCode)
		{
			UnitMeasure record = await this.UnitMeasureRepository.Get(unitMeasureCode);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalUnitMeasureMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiUnitMeasureServerResponseModel>> Create(
			ApiUnitMeasureServerRequestModel model)
		{
			CreateResponse<ApiUnitMeasureServerResponseModel> response = ValidationResponseFactory<ApiUnitMeasureServerResponseModel>.CreateResponse(await this.UnitMeasureModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				UnitMeasure record = this.DalUnitMeasureMapper.MapModelToEntity(default(string), model);
				record = await this.UnitMeasureRepository.Create(record);

				response.SetRecord(this.DalUnitMeasureMapper.MapEntityToModel(record));
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
				UnitMeasure record = this.DalUnitMeasureMapper.MapModelToEntity(unitMeasureCode, model);
				await this.UnitMeasureRepository.Update(record);

				record = await this.UnitMeasureRepository.Get(unitMeasureCode);

				ApiUnitMeasureServerResponseModel apiModel = this.DalUnitMeasureMapper.MapEntityToModel(record);
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
				return this.DalUnitMeasureMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiBillOfMaterialServerResponseModel>> BillOfMaterialsByUnitMeasureCode(string unitMeasureCode, int limit = int.MaxValue, int offset = 0)
		{
			List<BillOfMaterial> records = await this.UnitMeasureRepository.BillOfMaterialsByUnitMeasureCode(unitMeasureCode, limit, offset);

			return this.DalBillOfMaterialMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiProductServerResponseModel>> ProductsBySizeUnitMeasureCode(string sizeUnitMeasureCode, int limit = int.MaxValue, int offset = 0)
		{
			List<Product> records = await this.UnitMeasureRepository.ProductsBySizeUnitMeasureCode(sizeUnitMeasureCode, limit, offset);

			return this.DalProductMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiProductServerResponseModel>> ProductsByWeightUnitMeasureCode(string weightUnitMeasureCode, int limit = int.MaxValue, int offset = 0)
		{
			List<Product> records = await this.UnitMeasureRepository.ProductsByWeightUnitMeasureCode(weightUnitMeasureCode, limit, offset);

			return this.DalProductMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>adfdc20f25e8652effc4f31678f2448e</Hash>
</Codenesium>*/