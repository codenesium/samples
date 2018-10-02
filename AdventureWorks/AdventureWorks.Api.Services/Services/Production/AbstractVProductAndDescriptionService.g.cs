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
	public abstract class AbstractVProductAndDescriptionService : AbstractService
	{
		protected IVProductAndDescriptionRepository VProductAndDescriptionRepository { get; private set; }

		protected IApiVProductAndDescriptionRequestModelValidator VProductAndDescriptionModelValidator { get; private set; }

		protected IBOLVProductAndDescriptionMapper BolVProductAndDescriptionMapper { get; private set; }

		protected IDALVProductAndDescriptionMapper DalVProductAndDescriptionMapper { get; private set; }

		private ILogger logger;

		public AbstractVProductAndDescriptionService(
			ILogger logger,
			IVProductAndDescriptionRepository vProductAndDescriptionRepository,
			IApiVProductAndDescriptionRequestModelValidator vProductAndDescriptionModelValidator,
			IBOLVProductAndDescriptionMapper bolVProductAndDescriptionMapper,
			IDALVProductAndDescriptionMapper dalVProductAndDescriptionMapper)
			: base()
		{
			this.VProductAndDescriptionRepository = vProductAndDescriptionRepository;
			this.VProductAndDescriptionModelValidator = vProductAndDescriptionModelValidator;
			this.BolVProductAndDescriptionMapper = bolVProductAndDescriptionMapper;
			this.DalVProductAndDescriptionMapper = dalVProductAndDescriptionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVProductAndDescriptionResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VProductAndDescriptionRepository.All(limit, offset);

			return this.BolVProductAndDescriptionMapper.MapBOToModel(this.DalVProductAndDescriptionMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVProductAndDescriptionResponseModel> Get(string cultureID)
		{
			var record = await this.VProductAndDescriptionRepository.Get(cultureID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVProductAndDescriptionMapper.MapBOToModel(this.DalVProductAndDescriptionMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiVProductAndDescriptionResponseModel>> Create(
			ApiVProductAndDescriptionRequestModel model)
		{
			CreateResponse<ApiVProductAndDescriptionResponseModel> response = new CreateResponse<ApiVProductAndDescriptionResponseModel>(await this.VProductAndDescriptionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolVProductAndDescriptionMapper.MapModelToBO(default(string), model);
				var record = await this.VProductAndDescriptionRepository.Create(this.DalVProductAndDescriptionMapper.MapBOToEF(bo));

				response.SetRecord(this.BolVProductAndDescriptionMapper.MapBOToModel(this.DalVProductAndDescriptionMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVProductAndDescriptionResponseModel>> Update(
			string cultureID,
			ApiVProductAndDescriptionRequestModel model)
		{
			var validationResult = await this.VProductAndDescriptionModelValidator.ValidateUpdateAsync(cultureID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolVProductAndDescriptionMapper.MapModelToBO(cultureID, model);
				await this.VProductAndDescriptionRepository.Update(this.DalVProductAndDescriptionMapper.MapBOToEF(bo));

				var record = await this.VProductAndDescriptionRepository.Get(cultureID);

				return new UpdateResponse<ApiVProductAndDescriptionResponseModel>(this.BolVProductAndDescriptionMapper.MapBOToModel(this.DalVProductAndDescriptionMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiVProductAndDescriptionResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string cultureID)
		{
			ActionResponse response = new ActionResponse(await this.VProductAndDescriptionModelValidator.ValidateDeleteAsync(cultureID));
			if (response.Success)
			{
				await this.VProductAndDescriptionRepository.Delete(cultureID);
			}

			return response;
		}

		public async Task<ApiVProductAndDescriptionResponseModel> ByCultureIDProductID(string cultureID, int productID)
		{
			VProductAndDescription record = await this.VProductAndDescriptionRepository.ByCultureIDProductID(cultureID, productID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVProductAndDescriptionMapper.MapBOToModel(this.DalVProductAndDescriptionMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>12046ea8889bc050d4d7a0b0d0554929</Hash>
</Codenesium>*/