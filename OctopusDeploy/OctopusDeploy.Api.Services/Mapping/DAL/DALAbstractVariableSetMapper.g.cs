using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractVariableSetMapper
	{
		public virtual VariableSet MapBOToEF(
			BOVariableSet bo)
		{
			VariableSet efVariableSet = new VariableSet();
			efVariableSet.SetProperties(
				bo.Id,
				bo.IsFrozen,
				bo.JSON,
				bo.OwnerId,
				bo.RelatedDocumentIds,
				bo.Version);
			return efVariableSet;
		}

		public virtual BOVariableSet MapEFToBO(
			VariableSet ef)
		{
			var bo = new BOVariableSet();

			bo.SetProperties(
				ef.Id,
				ef.IsFrozen,
				ef.JSON,
				ef.OwnerId,
				ef.RelatedDocumentIds,
				ef.Version);
			return bo;
		}

		public virtual List<BOVariableSet> MapEFToBO(
			List<VariableSet> records)
		{
			List<BOVariableSet> response = new List<BOVariableSet>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>46e6bea5d77edfc48958d5e9cb957ec8</Hash>
</Codenesium>*/