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
	public abstract class AbstractCultureService : AbstractService
	{
		protected ICultureRepository CultureRepository { get; private set; }

		protected IApiCultureRequestModelValidator CultureModelValidator { get; private set; }

		protected IBOLCultureMapper BolCultureMapper { get; private set; }

		protected IDALCultureMapper DalCultureMapper { get; private set; }

		protected IBOLProductModelProductDescriptionCultureMapper BolProductModelProductDescriptionCultureMapper { get; private set; }

		protected IDALProductModelProductDescriptionCultureMapper DalProductModelProductDescriptionCultureMapper { get; private set; }

		private ILogger logger;

		public AbstractCultureService(
			ILogger logger,
			ICultureRepository cultureRepository,
			IApiCultureRequestModelValidator cultureModelValidator,
			IBOLCultureMapper bolCultureMapper,
			IDALCultureMapper dalCultureMapper,
			IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper,
			IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper)
			: base()
		{
			this.CultureRepository = cultureRepository;
			this.CultureModelValidator = cultureModelValidator;
			this.BolCultureMapper = bolCultureMapper;
			this.DalCultureMapper = dalCultureMapper;
			this.BolProductModelProductDescriptionCultureMapper = bolProductModelProductDescriptionCultureMapper;
			this.DalProductModelProductDescriptionCultureMapper = dalProductModelProductDescriptionCultureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCultureResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CultureRepository.All(limit, offset);

			return this.BolCultureMapper.MapBOToModel(this.DalCultureMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCultureResponseModel> Get(string cultureID)
		{
			var record = await this.CultureRepository.Get(cultureID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCultureMapper.MapBOToModel(this.DalCultureMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCultureResponseModel>> Create(
			ApiCultureRequestModel model)
		{
			CreateResponse<ApiCultureResponseModel> response = new CreateResponse<ApiCultureResponseModel>(await this.CultureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolCultureMapper.MapModelToBO(default(string), model);
				var record = await this.CultureRepository.Create(this.DalCultureMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCultureMapper.MapBOToModel(this.DalCultureMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCultureResponseModel>> Update(
			string cultureID,
			ApiCultureRequestModel model)
		{
			var validationResult = await this.CultureModelValidator.ValidateUpdateAsync(cultureID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCultureMapper.MapModelToBO(cultureID, model);
				await this.CultureRepository.Update(this.DalCultureMapper.MapBOToEF(bo));

				var record = await this.CultureRepository.Get(cultureID);

				return new UpdateResponse<ApiCultureResponseModel>(this.BolCultureMapper.MapBOToModel(this.DalCultureMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCultureResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string cultureID)
		{
			ActionResponse response = new ActionResponse(await this.CultureModelValidator.ValidateDeleteAsync(cultureID));
			if (response.Success)
			{
				await this.CultureRepository.Delete(cultureID);
			}

			return response;
		}

		public async Task<ApiCultureResponseModel> ByName(string name)
		{
			Culture record = await this.CultureRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCultureMapper.MapBOToModel(this.DalCultureMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCulturesByCultureID(string cultureID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductModelProductDescriptionCulture> records = await this.CultureRepository.ProductModelProductDescriptionCulturesByCultureID(cultureID, limit, offset);

			return this.BolProductModelProductDescriptionCultureMapper.MapBOToModel(this.DalProductModelProductDescriptionCultureMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>1f532723efd8cf0d01a70d21543323fc</Hash>
</Codenesium>*/