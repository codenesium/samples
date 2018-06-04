using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractHandlerService: AbstractService
	{
		private IHandlerRepository handlerRepository;
		private IApiHandlerRequestModelValidator handlerModelValidator;
		private IBOLHandlerMapper BOLHandlerMapper;
		private IDALHandlerMapper DALHandlerMapper;
		private ILogger logger;

		public AbstractHandlerService(
			ILogger logger,
			IHandlerRepository handlerRepository,
			IApiHandlerRequestModelValidator handlerModelValidator,
			IBOLHandlerMapper bolhandlerMapper,
			IDALHandlerMapper dalhandlerMapper)
			: base()

		{
			this.handlerRepository = handlerRepository;
			this.handlerModelValidator = handlerModelValidator;
			this.BOLHandlerMapper = bolhandlerMapper;
			this.DALHandlerMapper = dalhandlerMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiHandlerResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.handlerRepository.All(skip, take, orderClause);

			return this.BOLHandlerMapper.MapBOToModel(this.DALHandlerMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiHandlerResponseModel> Get(int id)
		{
			var record = await handlerRepository.Get(id);

			return this.BOLHandlerMapper.MapBOToModel(this.DALHandlerMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiHandlerResponseModel>> Create(
			ApiHandlerRequestModel model)
		{
			CreateResponse<ApiHandlerResponseModel> response = new CreateResponse<ApiHandlerResponseModel>(await this.handlerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLHandlerMapper.MapModelToBO(default (int), model);
				var record = await this.handlerRepository.Create(this.DALHandlerMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLHandlerMapper.MapBOToModel(this.DALHandlerMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiHandlerRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.handlerModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLHandlerMapper.MapModelToBO(id, model);
				await this.handlerRepository.Update(this.DALHandlerMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.handlerModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.handlerRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>42863340b70300d6f4fb64c73ad48a01</Hash>
</Codenesium>*/