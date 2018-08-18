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
	public abstract class AbstractSpecialOfferService : AbstractService
	{
		protected ISpecialOfferRepository SpecialOfferRepository { get; private set; }

		protected IApiSpecialOfferRequestModelValidator SpecialOfferModelValidator { get; private set; }

		protected IBOLSpecialOfferMapper BolSpecialOfferMapper { get; private set; }

		protected IDALSpecialOfferMapper DalSpecialOfferMapper { get; private set; }

		protected IBOLSpecialOfferProductMapper BolSpecialOfferProductMapper { get; private set; }

		protected IDALSpecialOfferProductMapper DalSpecialOfferProductMapper { get; private set; }

		private ILogger logger;

		public AbstractSpecialOfferService(
			ILogger logger,
			ISpecialOfferRepository specialOfferRepository,
			IApiSpecialOfferRequestModelValidator specialOfferModelValidator,
			IBOLSpecialOfferMapper bolSpecialOfferMapper,
			IDALSpecialOfferMapper dalSpecialOfferMapper,
			IBOLSpecialOfferProductMapper bolSpecialOfferProductMapper,
			IDALSpecialOfferProductMapper dalSpecialOfferProductMapper)
			: base()
		{
			this.SpecialOfferRepository = specialOfferRepository;
			this.SpecialOfferModelValidator = specialOfferModelValidator;
			this.BolSpecialOfferMapper = bolSpecialOfferMapper;
			this.DalSpecialOfferMapper = dalSpecialOfferMapper;
			this.BolSpecialOfferProductMapper = bolSpecialOfferProductMapper;
			this.DalSpecialOfferProductMapper = dalSpecialOfferProductMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpecialOfferResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SpecialOfferRepository.All(limit, offset);

			return this.BolSpecialOfferMapper.MapBOToModel(this.DalSpecialOfferMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSpecialOfferResponseModel> Get(int specialOfferID)
		{
			var record = await this.SpecialOfferRepository.Get(specialOfferID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSpecialOfferMapper.MapBOToModel(this.DalSpecialOfferMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSpecialOfferResponseModel>> Create(
			ApiSpecialOfferRequestModel model)
		{
			CreateResponse<ApiSpecialOfferResponseModel> response = new CreateResponse<ApiSpecialOfferResponseModel>(await this.SpecialOfferModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSpecialOfferMapper.MapModelToBO(default(int), model);
				var record = await this.SpecialOfferRepository.Create(this.DalSpecialOfferMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSpecialOfferMapper.MapBOToModel(this.DalSpecialOfferMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSpecialOfferResponseModel>> Update(
			int specialOfferID,
			ApiSpecialOfferRequestModel model)
		{
			var validationResult = await this.SpecialOfferModelValidator.ValidateUpdateAsync(specialOfferID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSpecialOfferMapper.MapModelToBO(specialOfferID, model);
				await this.SpecialOfferRepository.Update(this.DalSpecialOfferMapper.MapBOToEF(bo));

				var record = await this.SpecialOfferRepository.Get(specialOfferID);

				return new UpdateResponse<ApiSpecialOfferResponseModel>(this.BolSpecialOfferMapper.MapBOToModel(this.DalSpecialOfferMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSpecialOfferResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int specialOfferID)
		{
			ActionResponse response = new ActionResponse(await this.SpecialOfferModelValidator.ValidateDeleteAsync(specialOfferID));
			if (response.Success)
			{
				await this.SpecialOfferRepository.Delete(specialOfferID);
			}

			return response;
		}

		public async virtual Task<List<ApiSpecialOfferProductResponseModel>> SpecialOfferProducts(int specialOfferID, int limit = int.MaxValue, int offset = 0)
		{
			List<SpecialOfferProduct> records = await this.SpecialOfferRepository.SpecialOfferProducts(specialOfferID, limit, offset);

			return this.BolSpecialOfferProductMapper.MapBOToModel(this.DalSpecialOfferProductMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>e18ec96a8c3d6d41af5185a4034d4908</Hash>
</Codenesium>*/