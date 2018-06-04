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
	public abstract class AbstractOtherTransportService: AbstractService
	{
		private IOtherTransportRepository otherTransportRepository;
		private IApiOtherTransportRequestModelValidator otherTransportModelValidator;
		private IBOLOtherTransportMapper BOLOtherTransportMapper;
		private IDALOtherTransportMapper DALOtherTransportMapper;
		private ILogger logger;

		public AbstractOtherTransportService(
			ILogger logger,
			IOtherTransportRepository otherTransportRepository,
			IApiOtherTransportRequestModelValidator otherTransportModelValidator,
			IBOLOtherTransportMapper bolotherTransportMapper,
			IDALOtherTransportMapper dalotherTransportMapper)
			: base()

		{
			this.otherTransportRepository = otherTransportRepository;
			this.otherTransportModelValidator = otherTransportModelValidator;
			this.BOLOtherTransportMapper = bolotherTransportMapper;
			this.DALOtherTransportMapper = dalotherTransportMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiOtherTransportResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.otherTransportRepository.All(skip, take, orderClause);

			return this.BOLOtherTransportMapper.MapBOToModel(this.DALOtherTransportMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiOtherTransportResponseModel> Get(int id)
		{
			var record = await otherTransportRepository.Get(id);

			return this.BOLOtherTransportMapper.MapBOToModel(this.DALOtherTransportMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiOtherTransportResponseModel>> Create(
			ApiOtherTransportRequestModel model)
		{
			CreateResponse<ApiOtherTransportResponseModel> response = new CreateResponse<ApiOtherTransportResponseModel>(await this.otherTransportModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLOtherTransportMapper.MapModelToBO(default (int), model);
				var record = await this.otherTransportRepository.Create(this.DALOtherTransportMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLOtherTransportMapper.MapBOToModel(this.DALOtherTransportMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiOtherTransportRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.otherTransportModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLOtherTransportMapper.MapModelToBO(id, model);
				await this.otherTransportRepository.Update(this.DALOtherTransportMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.otherTransportModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.otherTransportRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e528119b50b1e3bc1b813a42d8280cb3</Hash>
</Codenesium>*/