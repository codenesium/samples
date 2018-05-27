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

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOSpecialOffer: AbstractBOManager
	{
		private ISpecialOfferRepository specialOfferRepository;
		private IApiSpecialOfferRequestModelValidator specialOfferModelValidator;
		private IBOLSpecialOfferMapper specialOfferMapper;
		private ILogger logger;

		public AbstractBOSpecialOffer(
			ILogger logger,
			ISpecialOfferRepository specialOfferRepository,
			IApiSpecialOfferRequestModelValidator specialOfferModelValidator,
			IBOLSpecialOfferMapper specialOfferMapper)
			: base()

		{
			this.specialOfferRepository = specialOfferRepository;
			this.specialOfferModelValidator = specialOfferModelValidator;
			this.specialOfferMapper = specialOfferMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpecialOfferResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.specialOfferRepository.All(skip, take, orderClause);

			return this.specialOfferMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiSpecialOfferResponseModel> Get(int specialOfferID)
		{
			var record = await specialOfferRepository.Get(specialOfferID);

			return this.specialOfferMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiSpecialOfferResponseModel>> Create(
			ApiSpecialOfferRequestModel model)
		{
			CreateResponse<ApiSpecialOfferResponseModel> response = new CreateResponse<ApiSpecialOfferResponseModel>(await this.specialOfferModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.specialOfferMapper.MapModelToDTO(default (int), model);
				var record = await this.specialOfferRepository.Create(dto);

				response.SetRecord(this.specialOfferMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int specialOfferID,
			ApiSpecialOfferRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.specialOfferModelValidator.ValidateUpdateAsync(specialOfferID, model));

			if (response.Success)
			{
				var dto = this.specialOfferMapper.MapModelToDTO(specialOfferID, model);
				await this.specialOfferRepository.Update(specialOfferID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int specialOfferID)
		{
			ActionResponse response = new ActionResponse(await this.specialOfferModelValidator.ValidateDeleteAsync(specialOfferID));

			if (response.Success)
			{
				await this.specialOfferRepository.Delete(specialOfferID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6eb021f81053ac7dff891b80cd6451ac</Hash>
</Codenesium>*/