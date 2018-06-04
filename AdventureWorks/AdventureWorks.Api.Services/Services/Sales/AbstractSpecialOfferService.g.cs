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
	public abstract class AbstractSpecialOfferService: AbstractService
	{
		private ISpecialOfferRepository specialOfferRepository;
		private IApiSpecialOfferRequestModelValidator specialOfferModelValidator;
		private IBOLSpecialOfferMapper BOLSpecialOfferMapper;
		private IDALSpecialOfferMapper DALSpecialOfferMapper;
		private ILogger logger;

		public AbstractSpecialOfferService(
			ILogger logger,
			ISpecialOfferRepository specialOfferRepository,
			IApiSpecialOfferRequestModelValidator specialOfferModelValidator,
			IBOLSpecialOfferMapper bolspecialOfferMapper,
			IDALSpecialOfferMapper dalspecialOfferMapper)
			: base()

		{
			this.specialOfferRepository = specialOfferRepository;
			this.specialOfferModelValidator = specialOfferModelValidator;
			this.BOLSpecialOfferMapper = bolspecialOfferMapper;
			this.DALSpecialOfferMapper = dalspecialOfferMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpecialOfferResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.specialOfferRepository.All(skip, take, orderClause);

			return this.BOLSpecialOfferMapper.MapBOToModel(this.DALSpecialOfferMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSpecialOfferResponseModel> Get(int specialOfferID)
		{
			var record = await specialOfferRepository.Get(specialOfferID);

			return this.BOLSpecialOfferMapper.MapBOToModel(this.DALSpecialOfferMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiSpecialOfferResponseModel>> Create(
			ApiSpecialOfferRequestModel model)
		{
			CreateResponse<ApiSpecialOfferResponseModel> response = new CreateResponse<ApiSpecialOfferResponseModel>(await this.specialOfferModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLSpecialOfferMapper.MapModelToBO(default (int), model);
				var record = await this.specialOfferRepository.Create(this.DALSpecialOfferMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLSpecialOfferMapper.MapBOToModel(this.DALSpecialOfferMapper.MapEFToBO(record)));
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
				var bo = this.BOLSpecialOfferMapper.MapModelToBO(specialOfferID, model);
				await this.specialOfferRepository.Update(this.DALSpecialOfferMapper.MapBOToEF(bo));
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
    <Hash>facc0a5020b65a1edd80f97e00297d45</Hash>
</Codenesium>*/