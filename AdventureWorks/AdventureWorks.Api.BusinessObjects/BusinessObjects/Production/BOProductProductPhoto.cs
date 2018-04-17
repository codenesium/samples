using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOProductProductPhoto: AbstractBOProductProductPhoto, IBOProductProductPhoto
	{
		public BOProductProductPhoto(
			ILogger<ProductProductPhotoRepository> logger,
			IProductProductPhotoRepository productProductPhotoRepository,
			IProductProductPhotoModelValidator productProductPhotoModelValidator)
			: base(logger, productProductPhotoRepository, productProductPhotoModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>9dca2068d60dde67b85af5bb90bd26f6</Hash>
</Codenesium>*/