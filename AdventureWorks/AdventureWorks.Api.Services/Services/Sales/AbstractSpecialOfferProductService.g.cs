using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractSpecialOfferProductService: AbstractService
	{
		private ISpecialOfferProductRepository specialOfferProductRepository;
		private IApiSpecialOfferProductRequestModelValidator specialOfferProductModelValidator;
		private IBOLSpecialOfferProductMapper BOLSpecialOfferProductMapper;
		private IDALSpecialOfferProductMapper DALSpecialOfferProductMapper;
		private ILogger logger;

		public AbstractSpecialOfferProductService(
			ILogger logger,
			ISpecialOfferProductRepository specialOfferProductRepository,
			IApiSpecialOfferProductRequestModelValidator specialOfferProductModelValidator,
			IBOLSpecialOfferProductMapper bolspecialOfferProductMapper,
			IDALSpecialOfferProductMapper dalspecialOfferProductMapper)
			: base()

		{
			this.specialOfferProductRepository = specialOfferProductRepository;
			this.specialOfferProductModelValidator = specialOfferProductModelValidator;
			this.BOLSpecialOfferProductMapper = bolspecialOfferProductMapper;
			this.DALSpecialOfferProductMapper = dalspecialOfferProductMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpecialOfferProductResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.specialOfferProductRepository.All(skip, take, orderClause);

			return this.BOLSpecialOfferProductMapper.MapBOToModel(this.DALSpecialOfferProductMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSpecialOfferProductResponseModel> Get(int specialOfferID)
		{
			var record = await specialOfferProductRepository.Get(specialOfferID);

			return this.BOLSpecialOfferProductMapper.MapBOToModel(this.DALSpecialOfferProductMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiSpecialOfferProductResponseModel>> Create(
			ApiSpecialOfferProductRequestModel model)
		{
			CreateResponse<ApiSpecialOfferProductResponseModel> response = new CreateResponse<ApiSpecialOfferProductResponseModel>(await this.specialOfferProductModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLSpecialOfferProductMapper.MapModelToBO(default (int), model);
				var record = await this.specialOfferProductRepository.Create(this.DALSpecialOfferProductMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLSpecialOfferProductMapper.MapBOToModel(this.DALSpecialOfferProductMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int specialOfferID,
			ApiSpecialOfferProductRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.specialOfferProductModelValidator.ValidateUpdateAsync(specialOfferID, model));

			if (response.Success)
			{
				var bo = this.BOLSpecialOfferProductMapper.MapModelToBO(specialOfferID, model);
				await this.specialOfferProductRepository.Update(this.DALSpecialOfferProductMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int specialOfferID)
		{
			ActionResponse response = new ActionResponse(await this.specialOfferProductModelValidator.ValidateDeleteAsync(specialOfferID));

			if (response.Success)
			{
				await this.specialOfferProductRepository.Delete(specialOfferID);
			}
			return response;
		}

		public async Task<List<ApiSpecialOfferProductResponseModel>> GetProductID(int productID)
		{
			List<SpecialOfferProduct> records = await this.specialOfferProductRepository.GetProductID(productID);

			return this.BOLSpecialOfferProductMapper.MapBOToModel(this.DALSpecialOfferProductMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>ab4ab28b3370bdda494c3aa0ec6f5d42</Hash>
</Codenesium>*/