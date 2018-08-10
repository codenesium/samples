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
	public abstract class AbstractBusinessEntityContactService : AbstractService
	{
		protected IBusinessEntityContactRepository BusinessEntityContactRepository { get; private set; }

		protected IApiBusinessEntityContactRequestModelValidator BusinessEntityContactModelValidator { get; private set; }

		protected IBOLBusinessEntityContactMapper BolBusinessEntityContactMapper { get; private set; }

		protected IDALBusinessEntityContactMapper DalBusinessEntityContactMapper { get; private set; }

		private ILogger logger;

		public AbstractBusinessEntityContactService(
			ILogger logger,
			IBusinessEntityContactRepository businessEntityContactRepository,
			IApiBusinessEntityContactRequestModelValidator businessEntityContactModelValidator,
			IBOLBusinessEntityContactMapper bolBusinessEntityContactMapper,
			IDALBusinessEntityContactMapper dalBusinessEntityContactMapper)
			: base()
		{
			this.BusinessEntityContactRepository = businessEntityContactRepository;
			this.BusinessEntityContactModelValidator = businessEntityContactModelValidator;
			this.BolBusinessEntityContactMapper = bolBusinessEntityContactMapper;
			this.DalBusinessEntityContactMapper = dalBusinessEntityContactMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiBusinessEntityContactResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.BusinessEntityContactRepository.All(limit, offset);

			return this.BolBusinessEntityContactMapper.MapBOToModel(this.DalBusinessEntityContactMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiBusinessEntityContactResponseModel> Get(int businessEntityID)
		{
			var record = await this.BusinessEntityContactRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolBusinessEntityContactMapper.MapBOToModel(this.DalBusinessEntityContactMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiBusinessEntityContactResponseModel>> Create(
			ApiBusinessEntityContactRequestModel model)
		{
			CreateResponse<ApiBusinessEntityContactResponseModel> response = new CreateResponse<ApiBusinessEntityContactResponseModel>(await this.BusinessEntityContactModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolBusinessEntityContactMapper.MapModelToBO(default(int), model);
				var record = await this.BusinessEntityContactRepository.Create(this.DalBusinessEntityContactMapper.MapBOToEF(bo));

				response.SetRecord(this.BolBusinessEntityContactMapper.MapBOToModel(this.DalBusinessEntityContactMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiBusinessEntityContactResponseModel>> Update(
			int businessEntityID,
			ApiBusinessEntityContactRequestModel model)
		{
			var validationResult = await this.BusinessEntityContactModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolBusinessEntityContactMapper.MapModelToBO(businessEntityID, model);
				await this.BusinessEntityContactRepository.Update(this.DalBusinessEntityContactMapper.MapBOToEF(bo));

				var record = await this.BusinessEntityContactRepository.Get(businessEntityID);

				return new UpdateResponse<ApiBusinessEntityContactResponseModel>(this.BolBusinessEntityContactMapper.MapBOToModel(this.DalBusinessEntityContactMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiBusinessEntityContactResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.BusinessEntityContactModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.BusinessEntityContactRepository.Delete(businessEntityID);
			}

			return response;
		}

		public async Task<List<ApiBusinessEntityContactResponseModel>> ByContactTypeID(int contactTypeID)
		{
			List<BusinessEntityContact> records = await this.BusinessEntityContactRepository.ByContactTypeID(contactTypeID);

			return this.BolBusinessEntityContactMapper.MapBOToModel(this.DalBusinessEntityContactMapper.MapEFToBO(records));
		}

		public async Task<List<ApiBusinessEntityContactResponseModel>> ByPersonID(int personID)
		{
			List<BusinessEntityContact> records = await this.BusinessEntityContactRepository.ByPersonID(personID);

			return this.BolBusinessEntityContactMapper.MapBOToModel(this.DalBusinessEntityContactMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>3477a5fe0e390f459cd20c5bd2ad15dc</Hash>
</Codenesium>*/