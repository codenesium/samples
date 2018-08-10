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
	public abstract class AbstractIllustrationService : AbstractService
	{
		protected IIllustrationRepository IllustrationRepository { get; private set; }

		protected IApiIllustrationRequestModelValidator IllustrationModelValidator { get; private set; }

		protected IBOLIllustrationMapper BolIllustrationMapper { get; private set; }

		protected IDALIllustrationMapper DalIllustrationMapper { get; private set; }

		protected IBOLProductModelIllustrationMapper BolProductModelIllustrationMapper { get; private set; }

		protected IDALProductModelIllustrationMapper DalProductModelIllustrationMapper { get; private set; }

		private ILogger logger;

		public AbstractIllustrationService(
			ILogger logger,
			IIllustrationRepository illustrationRepository,
			IApiIllustrationRequestModelValidator illustrationModelValidator,
			IBOLIllustrationMapper bolIllustrationMapper,
			IDALIllustrationMapper dalIllustrationMapper,
			IBOLProductModelIllustrationMapper bolProductModelIllustrationMapper,
			IDALProductModelIllustrationMapper dalProductModelIllustrationMapper)
			: base()
		{
			this.IllustrationRepository = illustrationRepository;
			this.IllustrationModelValidator = illustrationModelValidator;
			this.BolIllustrationMapper = bolIllustrationMapper;
			this.DalIllustrationMapper = dalIllustrationMapper;
			this.BolProductModelIllustrationMapper = bolProductModelIllustrationMapper;
			this.DalProductModelIllustrationMapper = dalProductModelIllustrationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiIllustrationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.IllustrationRepository.All(limit, offset);

			return this.BolIllustrationMapper.MapBOToModel(this.DalIllustrationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiIllustrationResponseModel> Get(int illustrationID)
		{
			var record = await this.IllustrationRepository.Get(illustrationID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolIllustrationMapper.MapBOToModel(this.DalIllustrationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiIllustrationResponseModel>> Create(
			ApiIllustrationRequestModel model)
		{
			CreateResponse<ApiIllustrationResponseModel> response = new CreateResponse<ApiIllustrationResponseModel>(await this.IllustrationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolIllustrationMapper.MapModelToBO(default(int), model);
				var record = await this.IllustrationRepository.Create(this.DalIllustrationMapper.MapBOToEF(bo));

				response.SetRecord(this.BolIllustrationMapper.MapBOToModel(this.DalIllustrationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiIllustrationResponseModel>> Update(
			int illustrationID,
			ApiIllustrationRequestModel model)
		{
			var validationResult = await this.IllustrationModelValidator.ValidateUpdateAsync(illustrationID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolIllustrationMapper.MapModelToBO(illustrationID, model);
				await this.IllustrationRepository.Update(this.DalIllustrationMapper.MapBOToEF(bo));

				var record = await this.IllustrationRepository.Get(illustrationID);

				return new UpdateResponse<ApiIllustrationResponseModel>(this.BolIllustrationMapper.MapBOToModel(this.DalIllustrationMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiIllustrationResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int illustrationID)
		{
			ActionResponse response = new ActionResponse(await this.IllustrationModelValidator.ValidateDeleteAsync(illustrationID));
			if (response.Success)
			{
				await this.IllustrationRepository.Delete(illustrationID);
			}

			return response;
		}

		public async virtual Task<List<ApiProductModelIllustrationResponseModel>> ProductModelIllustrations(int illustrationID, int limit = int.MaxValue, int offset = 0)
		{
			List<ProductModelIllustration> records = await this.IllustrationRepository.ProductModelIllustrations(illustrationID, limit, offset);

			return this.BolProductModelIllustrationMapper.MapBOToModel(this.DalProductModelIllustrationMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>08aef2953faedfadbef29f30bd4d6308</Hash>
</Codenesium>*/