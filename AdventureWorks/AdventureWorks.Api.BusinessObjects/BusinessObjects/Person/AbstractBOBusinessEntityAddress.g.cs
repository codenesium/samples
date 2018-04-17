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
	public abstract class AbstractBOBusinessEntityAddress
	{
		private IBusinessEntityAddressRepository businessEntityAddressRepository;
		private IBusinessEntityAddressModelValidator businessEntityAddressModelValidator;
		private ILogger logger;

		public AbstractBOBusinessEntityAddress(
			ILogger logger,
			IBusinessEntityAddressRepository businessEntityAddressRepository,
			IBusinessEntityAddressModelValidator businessEntityAddressModelValidator)

		{
			this.businessEntityAddressRepository = businessEntityAddressRepository;
			this.businessEntityAddressModelValidator = businessEntityAddressModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			BusinessEntityAddressModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.businessEntityAddressModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.businessEntityAddressRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			BusinessEntityAddressModel model)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityAddressModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				this.businessEntityAddressRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityAddressModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				this.businessEntityAddressRepository.Delete(businessEntityID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int businessEntityID)
		{
			return this.businessEntityAddressRepository.GetById(businessEntityID);
		}

		public virtual POCOBusinessEntityAddress GetByIdDirect(int businessEntityID)
		{
			return this.businessEntityAddressRepository.GetByIdDirect(businessEntityID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFBusinessEntityAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.businessEntityAddressRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.businessEntityAddressRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOBusinessEntityAddress> GetWhereDirect(Expression<Func<EFBusinessEntityAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.businessEntityAddressRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>eedbefe28ce3a1876d98e5266ff257ea</Hash>
</Codenesium>*/