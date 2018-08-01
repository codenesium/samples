using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractLibraryVariableSetMapper
	{
		public virtual LibraryVariableSet MapBOToEF(
			BOLibraryVariableSet bo)
		{
			LibraryVariableSet efLibraryVariableSet = new LibraryVariableSet();
			efLibraryVariableSet.SetProperties(
				bo.ContentType,
				bo.Id,
				bo.JSON,
				bo.Name,
				bo.VariableSetId);
			return efLibraryVariableSet;
		}

		public virtual BOLibraryVariableSet MapEFToBO(
			LibraryVariableSet ef)
		{
			var bo = new BOLibraryVariableSet();

			bo.SetProperties(
				ef.Id,
				ef.ContentType,
				ef.JSON,
				ef.Name,
				ef.VariableSetId);
			return bo;
		}

		public virtual List<BOLibraryVariableSet> MapEFToBO(
			List<LibraryVariableSet> records)
		{
			List<BOLibraryVariableSet> response = new List<BOLibraryVariableSet>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>711003e0400a18383e18e1acb8683288</Hash>
</Codenesium>*/