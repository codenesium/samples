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
	public abstract class AbstractAirlineService: AbstractService
	{
		private IAirlineRepository airlineRepository;
		private IApiAirlineRequestModelValidator airlineModelValidator;
		private IBOLAirlineMapper BOLAirlineMapper;
		private IDALAirlineMapper DALAirlineMapper;
		private ILogger logger;

		public AbstractAirlineService(
			ILogger logger,
			IAirlineRepository airlineRepository,
			IApiAirlineRequestModelValidator airlineModelValidator,
			IBOLAirlineMapper bolairlineMapper,
			IDALAirlineMapper dalairlineMapper)
			: base()

		{
			this.airlineRepository = airlineRepository;
			this.airlineModelValidator = airlineModelValidator;
			this.BOLAirlineMapper = bolairlineMapper;
			this.DALAirlineMapper = dalairlineMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAirlineResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.airlineRepository.All(skip, take, orderClause);

			return this.BOLAirlineMapper.MapBOToModel(this.DALAirlineMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAirlineResponseModel> Get(int id)
		{
			var record = await airlineRepository.Get(id);

			return this.BOLAirlineMapper.MapBOToModel(this.DALAirlineMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiAirlineResponseModel>> Create(
			ApiAirlineRequestModel model)
		{
			CreateResponse<ApiAirlineResponseModel> response = new CreateResponse<ApiAirlineResponseModel>(await this.airlineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLAirlineMapper.MapModelToBO(default (int), model);
				var record = await this.airlineRepository.Create(this.DALAirlineMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLAirlineMapper.MapBOToModel(this.DALAirlineMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiAirlineRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.airlineModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var bo = this.BOLAirlineMapper.MapModelToBO(id, model);
				await this.airlineRepository.Update(this.DALAirlineMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.airlineModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.airlineRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a2638aa318c586559d0eb1322e817612</Hash>
</Codenesium>*/