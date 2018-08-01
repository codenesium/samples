using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractTenantVariableMapper
	{
		public virtual TenantVariable MapBOToEF(
			BOTenantVariable bo)
		{
			TenantVariable efTenantVariable = new TenantVariable();
			efTenantVariable.SetProperties(
				bo.EnvironmentId,
				bo.Id,
				bo.JSON,
				bo.OwnerId,
				bo.RelatedDocumentId,
				bo.TenantId,
				bo.VariableTemplateId);
			return efTenantVariable;
		}

		public virtual BOTenantVariable MapEFToBO(
			TenantVariable ef)
		{
			var bo = new BOTenantVariable();

			bo.SetProperties(
				ef.Id,
				ef.EnvironmentId,
				ef.JSON,
				ef.OwnerId,
				ef.RelatedDocumentId,
				ef.TenantId,
				ef.VariableTemplateId);
			return bo;
		}

		public virtual List<BOTenantVariable> MapEFToBO(
			List<TenantVariable> records)
		{
			List<BOTenantVariable> response = new List<BOTenantVariable>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d1725c65f93133e72f56b003ca890295</Hash>
</Codenesium>*/