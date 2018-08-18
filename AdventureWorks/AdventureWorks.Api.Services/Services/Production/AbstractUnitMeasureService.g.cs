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
	public abstract class AbstractUnitMeasureService : AbstractService
	{
		protected IUnitMeasureRepository UnitMeasureRepository { get; private set; }

		protected IApiUnitMeasureRequestModelValidator UnitMeasureModelValidator { get; private set; }

		protected IBOLUnitMeasureMapper BolUnitMeasureMapper { get; private set; }

		protected IDALUnitMeasureMapper DalUnitMeasureMapper { get; private set; }

		protected IBOLBillOfMaterialMapper BolBillOfMaterialMapper { get; private set; }

		protected IDALBillOfMaterialMapper DalBillOfMaterialMapper { get; private set; }

		protected IBOLProductMapper BolProductMapper { get; private set; }

		protected IDALProductMapper DalProductMapper { get; private set; }

		private ILogger logger;

		public AbstractUnitMeasureService(
			ILogger logger,
			IUnitMeasureRepository unitMeasureRepository,
			IApiUnitMeasureRequestModelValidator unitMeasureModelValidator,
			IBOLUnitMeasureMapper bolUnitMeasureMapper,
			IDALUnitMeasureMapper dalUnitMeasureMapper,
			IBOLBillOfMaterialMapper bolBillOfMaterialMapper,
			IDALBillOfMaterialMapper dalBillOfMaterialMapper,
			IBOLProductMapper bolProductMapper,
			IDALProductMapper dalProductMapper)
			: base()
		{
			this.UnitMeasureRepository = unitMeasureRepository;
			this.UnitMeasureModelValidator = unitMeasureModelValidator;
			this.BolUnitMeasureMapper = bolUnitMeasureMapper;
			this.DalUnitMeasureMapper = dalUnitMeasureMapper;
			this.BolBillOfMaterialMapper = bolBillOfMaterialMapper;
			this.DalBillOfMaterialMapper = dalBillOfMaterialMapper;
			this.BolProductMapper = bolProductMapper;
			this.DalProductMapper = dalProductMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiUnitMeasureResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.UnitMeasureRepository.All(limit, offset);

			return this.BolUnitMeasureMapper.MapBOToModel(this.DalUnitMeasureMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiUnitMeasureResponseModel> Get(string unitMeasureCode)
		{
			var record = await this.UnitMeasureRepository.Get(unitMeasureCode);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolUnitMeasureMapper.MapBOToModel(this.DalUnitMeasureMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiUnitMeasureResponseModel>> Create(
			ApiUnitMeasureRequestModel model)
		{
			CreateResponse<ApiUnitMeasureResponseModel> response = new CreateResponse<ApiUnitMeasureResponseModel>(await this.UnitMeasureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolUnitMeasureMapper.MapModelToBO(default(string), model);
				var record = await this.UnitMeasureRepository.Create(this.DalUnitMeasureMapper.MapBOToEF(bo));

				response.SetRecord(this.BolUnitMeasureMapper.MapBOToModel(this.DalUnitMeasureMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiUnitMeasureResponseModel>> Update(
			string unitMeasureCode,
			ApiUnitMeasureRequestModel model)
		{
			var validationResult = await this.UnitMeasureModelValidator.ValidateUpdateAsync(unitMeasureCode, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolUnitMeasureMapper.MapModelToBO(unitMeasureCode, model);
				await this.UnitMeasureRepository.Update(this.DalUnitMeasureMapper.MapBOToEF(bo));

				var record = await this.UnitMeasureRepository.Get(unitMeasureCode);

				return new UpdateResponse<ApiUnitMeasureResponseModel>(this.BolUnitMeasureMapper.MapBOToModel(this.DalUnitMeasureMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiUnitMeasureResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string unitMeasureCode)
		{
			ActionResponse response = new ActionResponse(await this.UnitMeasureModelValidator.ValidateDeleteAsync(unitMeasureCode));
			if (response.Success)
			{
				await this.UnitMeasureRepository.Delete(unitMeasureCode);
			}

			return response;
		}

		public async Task<ApiUnitMeasureResponseModel> ByName(string name)
		{
			UnitMeasure record = await this.UnitMeasureRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolUnitMeasureMapper.MapBOToModel(this.DalUnitMeasureMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiBillOfMaterialResponseModel>> BillOfMaterials(string unitMeasureCode, int limit = int.MaxValue, int offset = 0)
		{
			List<BillOfMaterial> records = await this.UnitMeasureRepository.BillOfMaterials(unitMeasureCode, limit, offset);

			return this.BolBillOfMaterialMapper.MapBOToModel(this.DalBillOfMaterialMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiProductResponseModel>> Products(string sizeUnitMeasureCode, int limit = int.MaxValue, int offset = 0)
		{
			List<Product> records = await this.UnitMeasureRepository.Products(sizeUnitMeasureCode, limit, offset);

			return this.BolProductMapper.MapBOToModel(this.DalProductMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>a201b9abaf309cda466afecbb75da1d4</Hash>
</Codenesium>*/