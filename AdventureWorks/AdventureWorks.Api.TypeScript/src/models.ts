export class ApiAWBuildVersionClientRequestModel {
	database_Version : string;
	modifiedDate : string;
	systemInformationID : number;
	versionDate : string;

	constructor() {
		this.database_Version = '';
		this.modifiedDate = '';
		this.systemInformationID = 0;
		this.versionDate = '';
	}
}

export class ApiAWBuildVersionClientResponseModel {
	database_Version : string;
	modifiedDate : string;
	systemInformationID : number;
	versionDate : string;

	constructor() {
		this.database_Version = '';
		this.modifiedDate = '';
		this.systemInformationID = 0;
		this.versionDate = '';
	}
}
export class ApiDatabaseLogClientRequestModel {
	databaseLogID : number;
	databaseUser : string;
	event: string;
	object: string;
	postTime : string;
	schema : string;
	tsql : string;
	xmlEvent : string;

	constructor() {
		this.databaseLogID = 0;
		this.databaseUser = '';
		this.event = '';
		this.object = '';
		this.postTime = '';
		this.schema = '';
		this.tsql = '';
		this.xmlEvent = '';
	}
}

export class ApiDatabaseLogClientResponseModel {
	databaseLogID : number;
	databaseUser : string;
	event: string;
	object: string;
	postTime : string;
	schema : string;
	tsql : string;
	xmlEvent : string;

	constructor() {
		this.databaseLogID = 0;
		this.databaseUser = '';
		this.event = '';
		this.object = '';
		this.postTime = '';
		this.schema = '';
		this.tsql = '';
		this.xmlEvent = '';
	}
}
export class ApiErrorLogClientRequestModel {
	errorLine : number;
	errorLogID : number;
	errorMessage : string;
	errorNumber : number;
	errorProcedure : string;
	errorSeverity : number;
	errorState : number;
	errorTime : string;
	userName : string;

	constructor() {
		this.errorLine = 0;
		this.errorLogID = 0;
		this.errorMessage = '';
		this.errorNumber = 0;
		this.errorProcedure = '';
		this.errorSeverity = 0;
		this.errorState = 0;
		this.errorTime = '';
		this.userName = '';
	}
}

export class ApiErrorLogClientResponseModel {
	errorLine : number;
	errorLogID : number;
	errorMessage : string;
	errorNumber : number;
	errorProcedure : string;
	errorSeverity : number;
	errorState : number;
	errorTime : string;
	userName : string;

	constructor() {
		this.errorLine = 0;
		this.errorLogID = 0;
		this.errorMessage = '';
		this.errorNumber = 0;
		this.errorProcedure = '';
		this.errorSeverity = 0;
		this.errorState = 0;
		this.errorTime = '';
		this.userName = '';
	}
}
export class ApiDepartmentClientRequestModel {
	departmentID : number;
	groupName : string;
	modifiedDate : string;
	name : string;

	constructor() {
		this.departmentID = 0;
		this.groupName = '';
		this.modifiedDate = '';
		this.name = '';
	}
}

export class ApiDepartmentClientResponseModel {
	departmentID : number;
	groupName : string;
	modifiedDate : string;
	name : string;

	constructor() {
		this.departmentID = 0;
		this.groupName = '';
		this.modifiedDate = '';
		this.name = '';
	}
}
export class ApiEmployeeClientRequestModel {
	birthDate : string;
	businessEntityID : number;
	currentFlag : boolean;
	gender : string;
	hireDate : string;
	jobTitle : string;
	loginID : string;
	maritalStatu : string;
	modifiedDate : string;
	nationalIDNumber : string;
	organizationLevel : number;
	rowguid : string;
	salariedFlag : boolean;
	sickLeaveHour : number;
	vacationHour : number;

	constructor() {
		this.birthDate = '';
		this.businessEntityID = 0;
		this.currentFlag = false;
		this.gender = '';
		this.hireDate = '';
		this.jobTitle = '';
		this.loginID = '';
		this.maritalStatu = '';
		this.modifiedDate = '';
		this.nationalIDNumber = '';
		this.organizationLevel = 0;
		this.rowguid = '';
		this.salariedFlag = false;
		this.sickLeaveHour = 0;
		this.vacationHour = 0;
	}
}

export class ApiEmployeeClientResponseModel {
	birthDate : string;
	businessEntityID : number;
	currentFlag : boolean;
	gender : string;
	hireDate : string;
	jobTitle : string;
	loginID : string;
	maritalStatu : string;
	modifiedDate : string;
	nationalIDNumber : string;
	organizationLevel : number;
	rowguid : string;
	salariedFlag : boolean;
	sickLeaveHour : number;
	vacationHour : number;

	constructor() {
		this.birthDate = '';
		this.businessEntityID = 0;
		this.currentFlag = false;
		this.gender = '';
		this.hireDate = '';
		this.jobTitle = '';
		this.loginID = '';
		this.maritalStatu = '';
		this.modifiedDate = '';
		this.nationalIDNumber = '';
		this.organizationLevel = 0;
		this.rowguid = '';
		this.salariedFlag = false;
		this.sickLeaveHour = 0;
		this.vacationHour = 0;
	}
}
export class ApiJobCandidateClientRequestModel {
	businessEntityID : number;
	jobCandidateID : number;
	modifiedDate : string;
	resume : string;

	constructor() {
		this.businessEntityID = 0;
		this.jobCandidateID = 0;
		this.modifiedDate = '';
		this.resume = '';
	}
}

export class ApiJobCandidateClientResponseModel {
	businessEntityID : number;
	jobCandidateID : number;
	modifiedDate : string;
	resume : string;

	constructor() {
		this.businessEntityID = 0;
		this.jobCandidateID = 0;
		this.modifiedDate = '';
		this.resume = '';
	}
}
export class ApiShiftClientRequestModel {
	endTime : string;
	modifiedDate : string;
	name : string;
	shiftID : number;
	startTime : string;

	constructor() {
		this.endTime = '';
		this.modifiedDate = '';
		this.name = '';
		this.shiftID = 0;
		this.startTime = '';
	}
}

export class ApiShiftClientResponseModel {
	endTime : string;
	modifiedDate : string;
	name : string;
	shiftID : number;
	startTime : string;

	constructor() {
		this.endTime = '';
		this.modifiedDate = '';
		this.name = '';
		this.shiftID = 0;
		this.startTime = '';
	}
}
export class ApiAddressClientRequestModel {
	addressID : number;
	addressLine1 : string;
	addressLine2 : string;
	city : string;
	modifiedDate : string;
	postalCode : string;
	rowguid : string;
	stateProvinceID : number;

	constructor() {
		this.addressID = 0;
		this.addressLine1 = '';
		this.addressLine2 = '';
		this.city = '';
		this.modifiedDate = '';
		this.postalCode = '';
		this.rowguid = '';
		this.stateProvinceID = 0;
	}
}

export class ApiAddressClientResponseModel {
	addressID : number;
	addressLine1 : string;
	addressLine2 : string;
	city : string;
	modifiedDate : string;
	postalCode : string;
	rowguid : string;
	stateProvinceID : number;

	constructor() {
		this.addressID = 0;
		this.addressLine1 = '';
		this.addressLine2 = '';
		this.city = '';
		this.modifiedDate = '';
		this.postalCode = '';
		this.rowguid = '';
		this.stateProvinceID = 0;
	}
}
export class ApiAddressTypeClientRequestModel {
	addressTypeID : number;
	modifiedDate : string;
	name : string;
	rowguid : string;

	constructor() {
		this.addressTypeID = 0;
		this.modifiedDate = '';
		this.name = '';
		this.rowguid = '';
	}
}

export class ApiAddressTypeClientResponseModel {
	addressTypeID : number;
	modifiedDate : string;
	name : string;
	rowguid : string;

	constructor() {
		this.addressTypeID = 0;
		this.modifiedDate = '';
		this.name = '';
		this.rowguid = '';
	}
}
export class ApiBusinessEntityClientRequestModel {
	businessEntityID : number;
	modifiedDate : string;
	rowguid : string;

	constructor() {
		this.businessEntityID = 0;
		this.modifiedDate = '';
		this.rowguid = '';
	}
}

export class ApiBusinessEntityClientResponseModel {
	businessEntityID : number;
	modifiedDate : string;
	rowguid : string;

	constructor() {
		this.businessEntityID = 0;
		this.modifiedDate = '';
		this.rowguid = '';
	}
}
export class ApiContactTypeClientRequestModel {
	contactTypeID : number;
	modifiedDate : string;
	name : string;

	constructor() {
		this.contactTypeID = 0;
		this.modifiedDate = '';
		this.name = '';
	}
}

export class ApiContactTypeClientResponseModel {
	contactTypeID : number;
	modifiedDate : string;
	name : string;

	constructor() {
		this.contactTypeID = 0;
		this.modifiedDate = '';
		this.name = '';
	}
}
export class ApiCountryRegionClientRequestModel {
	countryRegionCode : string;
	modifiedDate : string;
	name : string;

	constructor() {
		this.countryRegionCode = '';
		this.modifiedDate = '';
		this.name = '';
	}
}

export class ApiCountryRegionClientResponseModel {
	countryRegionCode : string;
	modifiedDate : string;
	name : string;

	constructor() {
		this.countryRegionCode = '';
		this.modifiedDate = '';
		this.name = '';
	}
}
export class ApiPasswordClientRequestModel {
	businessEntityID : number;
	modifiedDate : string;
	passwordHash : string;
	passwordSalt : string;
	rowguid : string;

	constructor() {
		this.businessEntityID = 0;
		this.modifiedDate = '';
		this.passwordHash = '';
		this.passwordSalt = '';
		this.rowguid = '';
	}
}

export class ApiPasswordClientResponseModel {
	businessEntityID : number;
	modifiedDate : string;
	passwordHash : string;
	passwordSalt : string;
	rowguid : string;

	constructor() {
		this.businessEntityID = 0;
		this.modifiedDate = '';
		this.passwordHash = '';
		this.passwordSalt = '';
		this.rowguid = '';
	}
}
export class ApiPersonClientRequestModel {
	additionalContactInfo : string;
	businessEntityID : number;
	demographic : string;
	emailPromotion : number;
	firstName : string;
	lastName : string;
	middleName : string;
	modifiedDate : string;
	nameStyle : boolean;
	personType : string;
	rowguid : string;
	suffix : string;
	title : string;

	constructor() {
		this.additionalContactInfo = '';
		this.businessEntityID = 0;
		this.demographic = '';
		this.emailPromotion = 0;
		this.firstName = '';
		this.lastName = '';
		this.middleName = '';
		this.modifiedDate = '';
		this.nameStyle = false;
		this.personType = '';
		this.rowguid = '';
		this.suffix = '';
		this.title = '';
	}
}

export class ApiPersonClientResponseModel {
	additionalContactInfo : string;
	businessEntityID : number;
	demographic : string;
	emailPromotion : number;
	firstName : string;
	lastName : string;
	middleName : string;
	modifiedDate : string;
	nameStyle : boolean;
	personType : string;
	rowguid : string;
	suffix : string;
	title : string;

	constructor() {
		this.additionalContactInfo = '';
		this.businessEntityID = 0;
		this.demographic = '';
		this.emailPromotion = 0;
		this.firstName = '';
		this.lastName = '';
		this.middleName = '';
		this.modifiedDate = '';
		this.nameStyle = false;
		this.personType = '';
		this.rowguid = '';
		this.suffix = '';
		this.title = '';
	}
}
export class ApiPhoneNumberTypeClientRequestModel {
	modifiedDate : string;
	name : string;
	phoneNumberTypeID : number;

	constructor() {
		this.modifiedDate = '';
		this.name = '';
		this.phoneNumberTypeID = 0;
	}
}

export class ApiPhoneNumberTypeClientResponseModel {
	modifiedDate : string;
	name : string;
	phoneNumberTypeID : number;

	constructor() {
		this.modifiedDate = '';
		this.name = '';
		this.phoneNumberTypeID = 0;
	}
}
export class ApiStateProvinceClientRequestModel {
	countryRegionCode : string;
	isOnlyStateProvinceFlag : boolean;
	modifiedDate : string;
	name : string;
	rowguid : string;
	stateProvinceCode : string;
	stateProvinceID : number;
	territoryID : number;

	constructor() {
		this.countryRegionCode = '';
		this.isOnlyStateProvinceFlag = false;
		this.modifiedDate = '';
		this.name = '';
		this.rowguid = '';
		this.stateProvinceCode = '';
		this.stateProvinceID = 0;
		this.territoryID = 0;
	}
}

export class ApiStateProvinceClientResponseModel {
	countryRegionCode : string;
	isOnlyStateProvinceFlag : boolean;
	modifiedDate : string;
	name : string;
	rowguid : string;
	stateProvinceCode : string;
	stateProvinceID : number;
	territoryID : number;

	constructor() {
		this.countryRegionCode = '';
		this.isOnlyStateProvinceFlag = false;
		this.modifiedDate = '';
		this.name = '';
		this.rowguid = '';
		this.stateProvinceCode = '';
		this.stateProvinceID = 0;
		this.territoryID = 0;
	}
}
export class ApiBillOfMaterialClientRequestModel {
	billOfMaterialsID : number;
	bOMLevel : number;
	componentID : number;
	endDate : string;
	modifiedDate : string;
	perAssemblyQty : number;
	productAssemblyID : number;
	startDate : string;
	unitMeasureCode : string;

	constructor() {
		this.billOfMaterialsID = 0;
		this.bOMLevel = 0;
		this.componentID = 0;
		this.endDate = '';
		this.modifiedDate = '';
		this.perAssemblyQty = 0;
		this.productAssemblyID = 0;
		this.startDate = '';
		this.unitMeasureCode = '';
	}
}

export class ApiBillOfMaterialClientResponseModel {
	billOfMaterialsID : number;
	bOMLevel : number;
	componentID : number;
	endDate : string;
	modifiedDate : string;
	perAssemblyQty : number;
	productAssemblyID : number;
	startDate : string;
	unitMeasureCode : string;

	constructor() {
		this.billOfMaterialsID = 0;
		this.bOMLevel = 0;
		this.componentID = 0;
		this.endDate = '';
		this.modifiedDate = '';
		this.perAssemblyQty = 0;
		this.productAssemblyID = 0;
		this.startDate = '';
		this.unitMeasureCode = '';
	}
}
export class ApiCultureClientRequestModel {
	cultureID : string;
	modifiedDate : string;
	name : string;

	constructor() {
		this.cultureID = '';
		this.modifiedDate = '';
		this.name = '';
	}
}

export class ApiCultureClientResponseModel {
	cultureID : string;
	modifiedDate : string;
	name : string;

	constructor() {
		this.cultureID = '';
		this.modifiedDate = '';
		this.name = '';
	}
}
export class ApiDocumentClientRequestModel {
	changeNumber : number;
	document1 : string;
	documentLevel : number;
	documentSummary : string;
	fileExtension : string;
	fileName : string;
	folderFlag : boolean;
	modifiedDate : string;
	owner : number;
	revision : string;
	rowguid : string;
	status : number;
	title : string;

	constructor() {
		this.changeNumber = 0;
		this.document1 = '';
		this.documentLevel = 0;
		this.documentSummary = '';
		this.fileExtension = '';
		this.fileName = '';
		this.folderFlag = false;
		this.modifiedDate = '';
		this.owner = 0;
		this.revision = '';
		this.rowguid = '';
		this.status = 0;
		this.title = '';
	}
}

export class ApiDocumentClientResponseModel {
	changeNumber : number;
	document1 : string;
	documentLevel : number;
	documentSummary : string;
	fileExtension : string;
	fileName : string;
	folderFlag : boolean;
	modifiedDate : string;
	owner : number;
	revision : string;
	rowguid : string;
	status : number;
	title : string;

	constructor() {
		this.changeNumber = 0;
		this.document1 = '';
		this.documentLevel = 0;
		this.documentSummary = '';
		this.fileExtension = '';
		this.fileName = '';
		this.folderFlag = false;
		this.modifiedDate = '';
		this.owner = 0;
		this.revision = '';
		this.rowguid = '';
		this.status = 0;
		this.title = '';
	}
}
export class ApiIllustrationClientRequestModel {
	diagram : string;
	illustrationID : number;
	modifiedDate : string;

	constructor() {
		this.diagram = '';
		this.illustrationID = 0;
		this.modifiedDate = '';
	}
}

export class ApiIllustrationClientResponseModel {
	diagram : string;
	illustrationID : number;
	modifiedDate : string;

	constructor() {
		this.diagram = '';
		this.illustrationID = 0;
		this.modifiedDate = '';
	}
}
export class ApiLocationClientRequestModel {
	availability : number;
	costRate : number;
	locationID : number;
	modifiedDate : string;
	name : string;

	constructor() {
		this.availability = 0;
		this.costRate = 0;
		this.locationID = 0;
		this.modifiedDate = '';
		this.name = '';
	}
}

export class ApiLocationClientResponseModel {
	availability : number;
	costRate : number;
	locationID : number;
	modifiedDate : string;
	name : string;

	constructor() {
		this.availability = 0;
		this.costRate = 0;
		this.locationID = 0;
		this.modifiedDate = '';
		this.name = '';
	}
}
export class ApiProductClientRequestModel {
	class : string;
	color : string;
	daysToManufacture : number;
	discontinuedDate : string;
	finishedGoodsFlag : boolean;
	listPrice : number;
	makeFlag : boolean;
	modifiedDate : string;
	name : string;
	productID : number;
	productLine : string;
	productModelID : number;
	productNumber : string;
	productSubcategoryID : number;
	reorderPoint : number;
	rowguid : string;
	safetyStockLevel : number;
	sellEndDate : string;
	sellStartDate : string;
	size : string;
	sizeUnitMeasureCode : string;
	standardCost : number;
	style : string;
	weight : number;
	weightUnitMeasureCode : string;

	constructor() {
		this.class = '';
		this.color = '';
		this.daysToManufacture = 0;
		this.discontinuedDate = '';
		this.finishedGoodsFlag = false;
		this.listPrice = 0;
		this.makeFlag = false;
		this.modifiedDate = '';
		this.name = '';
		this.productID = 0;
		this.productLine = '';
		this.productModelID = 0;
		this.productNumber = '';
		this.productSubcategoryID = 0;
		this.reorderPoint = 0;
		this.rowguid = '';
		this.safetyStockLevel = 0;
		this.sellEndDate = '';
		this.sellStartDate = '';
		this.size = '';
		this.sizeUnitMeasureCode = '';
		this.standardCost = 0;
		this.style = '';
		this.weight = 0;
		this.weightUnitMeasureCode = '';
	}
}

export class ApiProductClientResponseModel {
	class : string;
	color : string;
	daysToManufacture : number;
	discontinuedDate : string;
	finishedGoodsFlag : boolean;
	listPrice : number;
	makeFlag : boolean;
	modifiedDate : string;
	name : string;
	productID : number;
	productLine : string;
	productModelID : number;
	productNumber : string;
	productSubcategoryID : number;
	reorderPoint : number;
	rowguid : string;
	safetyStockLevel : number;
	sellEndDate : string;
	sellStartDate : string;
	size : string;
	sizeUnitMeasureCode : string;
	standardCost : number;
	style : string;
	weight : number;
	weightUnitMeasureCode : string;

	constructor() {
		this.class = '';
		this.color = '';
		this.daysToManufacture = 0;
		this.discontinuedDate = '';
		this.finishedGoodsFlag = false;
		this.listPrice = 0;
		this.makeFlag = false;
		this.modifiedDate = '';
		this.name = '';
		this.productID = 0;
		this.productLine = '';
		this.productModelID = 0;
		this.productNumber = '';
		this.productSubcategoryID = 0;
		this.reorderPoint = 0;
		this.rowguid = '';
		this.safetyStockLevel = 0;
		this.sellEndDate = '';
		this.sellStartDate = '';
		this.size = '';
		this.sizeUnitMeasureCode = '';
		this.standardCost = 0;
		this.style = '';
		this.weight = 0;
		this.weightUnitMeasureCode = '';
	}
}
export class ApiProductCategoryClientRequestModel {
	modifiedDate : string;
	name : string;
	productCategoryID : number;
	rowguid : string;

	constructor() {
		this.modifiedDate = '';
		this.name = '';
		this.productCategoryID = 0;
		this.rowguid = '';
	}
}

export class ApiProductCategoryClientResponseModel {
	modifiedDate : string;
	name : string;
	productCategoryID : number;
	rowguid : string;

	constructor() {
		this.modifiedDate = '';
		this.name = '';
		this.productCategoryID = 0;
		this.rowguid = '';
	}
}
export class ApiProductDescriptionClientRequestModel {
	description : string;
	modifiedDate : string;
	productDescriptionID : number;
	rowguid : string;

	constructor() {
		this.description = '';
		this.modifiedDate = '';
		this.productDescriptionID = 0;
		this.rowguid = '';
	}
}

export class ApiProductDescriptionClientResponseModel {
	description : string;
	modifiedDate : string;
	productDescriptionID : number;
	rowguid : string;

	constructor() {
		this.description = '';
		this.modifiedDate = '';
		this.productDescriptionID = 0;
		this.rowguid = '';
	}
}
export class ApiProductModelClientRequestModel {
	catalogDescription : string;
	instruction : string;
	modifiedDate : string;
	name : string;
	productModelID : number;
	rowguid : string;

	constructor() {
		this.catalogDescription = '';
		this.instruction = '';
		this.modifiedDate = '';
		this.name = '';
		this.productModelID = 0;
		this.rowguid = '';
	}
}

export class ApiProductModelClientResponseModel {
	catalogDescription : string;
	instruction : string;
	modifiedDate : string;
	name : string;
	productModelID : number;
	rowguid : string;

	constructor() {
		this.catalogDescription = '';
		this.instruction = '';
		this.modifiedDate = '';
		this.name = '';
		this.productModelID = 0;
		this.rowguid = '';
	}
}
export class ApiProductPhotoClientRequestModel {
	largePhoto : string;
	largePhotoFileName : string;
	modifiedDate : string;
	productPhotoID : number;
	thumbNailPhoto : string;
	thumbnailPhotoFileName : string;

	constructor() {
		this.largePhoto = '';
		this.largePhotoFileName = '';
		this.modifiedDate = '';
		this.productPhotoID = 0;
		this.thumbNailPhoto = '';
		this.thumbnailPhotoFileName = '';
	}
}

export class ApiProductPhotoClientResponseModel {
	largePhoto : string;
	largePhotoFileName : string;
	modifiedDate : string;
	productPhotoID : number;
	thumbNailPhoto : string;
	thumbnailPhotoFileName : string;

	constructor() {
		this.largePhoto = '';
		this.largePhotoFileName = '';
		this.modifiedDate = '';
		this.productPhotoID = 0;
		this.thumbNailPhoto = '';
		this.thumbnailPhotoFileName = '';
	}
}
export class ApiProductReviewClientRequestModel {
	comment : string;
	emailAddress : string;
	modifiedDate : string;
	productID : number;
	productReviewID : number;
	rating : number;
	reviewDate : string;
	reviewerName : string;

	constructor() {
		this.comment = '';
		this.emailAddress = '';
		this.modifiedDate = '';
		this.productID = 0;
		this.productReviewID = 0;
		this.rating = 0;
		this.reviewDate = '';
		this.reviewerName = '';
	}
}

export class ApiProductReviewClientResponseModel {
	comment : string;
	emailAddress : string;
	modifiedDate : string;
	productID : number;
	productReviewID : number;
	rating : number;
	reviewDate : string;
	reviewerName : string;

	constructor() {
		this.comment = '';
		this.emailAddress = '';
		this.modifiedDate = '';
		this.productID = 0;
		this.productReviewID = 0;
		this.rating = 0;
		this.reviewDate = '';
		this.reviewerName = '';
	}
}
export class ApiProductSubcategoryClientRequestModel {
	modifiedDate : string;
	name : string;
	productCategoryID : number;
	productSubcategoryID : number;
	rowguid : string;

	constructor() {
		this.modifiedDate = '';
		this.name = '';
		this.productCategoryID = 0;
		this.productSubcategoryID = 0;
		this.rowguid = '';
	}
}

export class ApiProductSubcategoryClientResponseModel {
	modifiedDate : string;
	name : string;
	productCategoryID : number;
	productSubcategoryID : number;
	rowguid : string;

	constructor() {
		this.modifiedDate = '';
		this.name = '';
		this.productCategoryID = 0;
		this.productSubcategoryID = 0;
		this.rowguid = '';
	}
}
export class ApiScrapReasonClientRequestModel {
	modifiedDate : string;
	name : string;
	scrapReasonID : number;

	constructor() {
		this.modifiedDate = '';
		this.name = '';
		this.scrapReasonID = 0;
	}
}

export class ApiScrapReasonClientResponseModel {
	modifiedDate : string;
	name : string;
	scrapReasonID : number;

	constructor() {
		this.modifiedDate = '';
		this.name = '';
		this.scrapReasonID = 0;
	}
}
export class ApiTransactionHistoryClientRequestModel {
	actualCost : number;
	modifiedDate : string;
	productID : number;
	quantity : number;
	referenceOrderID : number;
	referenceOrderLineID : number;
	transactionDate : string;
	transactionID : number;
	transactionType : string;

	constructor() {
		this.actualCost = 0;
		this.modifiedDate = '';
		this.productID = 0;
		this.quantity = 0;
		this.referenceOrderID = 0;
		this.referenceOrderLineID = 0;
		this.transactionDate = '';
		this.transactionID = 0;
		this.transactionType = '';
	}
}

export class ApiTransactionHistoryClientResponseModel {
	actualCost : number;
	modifiedDate : string;
	productID : number;
	quantity : number;
	referenceOrderID : number;
	referenceOrderLineID : number;
	transactionDate : string;
	transactionID : number;
	transactionType : string;

	constructor() {
		this.actualCost = 0;
		this.modifiedDate = '';
		this.productID = 0;
		this.quantity = 0;
		this.referenceOrderID = 0;
		this.referenceOrderLineID = 0;
		this.transactionDate = '';
		this.transactionID = 0;
		this.transactionType = '';
	}
}
export class ApiTransactionHistoryArchiveClientRequestModel {
	actualCost : number;
	modifiedDate : string;
	productID : number;
	quantity : number;
	referenceOrderID : number;
	referenceOrderLineID : number;
	transactionDate : string;
	transactionID : number;
	transactionType : string;

	constructor() {
		this.actualCost = 0;
		this.modifiedDate = '';
		this.productID = 0;
		this.quantity = 0;
		this.referenceOrderID = 0;
		this.referenceOrderLineID = 0;
		this.transactionDate = '';
		this.transactionID = 0;
		this.transactionType = '';
	}
}

export class ApiTransactionHistoryArchiveClientResponseModel {
	actualCost : number;
	modifiedDate : string;
	productID : number;
	quantity : number;
	referenceOrderID : number;
	referenceOrderLineID : number;
	transactionDate : string;
	transactionID : number;
	transactionType : string;

	constructor() {
		this.actualCost = 0;
		this.modifiedDate = '';
		this.productID = 0;
		this.quantity = 0;
		this.referenceOrderID = 0;
		this.referenceOrderLineID = 0;
		this.transactionDate = '';
		this.transactionID = 0;
		this.transactionType = '';
	}
}
export class ApiUnitMeasureClientRequestModel {
	modifiedDate : string;
	name : string;
	unitMeasureCode : string;

	constructor() {
		this.modifiedDate = '';
		this.name = '';
		this.unitMeasureCode = '';
	}
}

export class ApiUnitMeasureClientResponseModel {
	modifiedDate : string;
	name : string;
	unitMeasureCode : string;

	constructor() {
		this.modifiedDate = '';
		this.name = '';
		this.unitMeasureCode = '';
	}
}
export class ApiWorkOrderClientRequestModel {
	dueDate : string;
	endDate : string;
	modifiedDate : string;
	orderQty : number;
	productID : number;
	scrappedQty : number;
	scrapReasonID : number;
	startDate : string;
	stockedQty : number;
	workOrderID : number;

	constructor() {
		this.dueDate = '';
		this.endDate = '';
		this.modifiedDate = '';
		this.orderQty = 0;
		this.productID = 0;
		this.scrappedQty = 0;
		this.scrapReasonID = 0;
		this.startDate = '';
		this.stockedQty = 0;
		this.workOrderID = 0;
	}
}

export class ApiWorkOrderClientResponseModel {
	dueDate : string;
	endDate : string;
	modifiedDate : string;
	orderQty : number;
	productID : number;
	scrappedQty : number;
	scrapReasonID : number;
	startDate : string;
	stockedQty : number;
	workOrderID : number;

	constructor() {
		this.dueDate = '';
		this.endDate = '';
		this.modifiedDate = '';
		this.orderQty = 0;
		this.productID = 0;
		this.scrappedQty = 0;
		this.scrapReasonID = 0;
		this.startDate = '';
		this.stockedQty = 0;
		this.workOrderID = 0;
	}
}
export class ApiPurchaseOrderHeaderClientRequestModel {
	employeeID : number;
	freight : number;
	modifiedDate : string;
	orderDate : string;
	purchaseOrderID : number;
	revisionNumber : number;
	shipDate : string;
	shipMethodID : number;
	status : number;
	subTotal : number;
	taxAmt : number;
	totalDue : number;
	vendorID : number;

	constructor() {
		this.employeeID = 0;
		this.freight = 0;
		this.modifiedDate = '';
		this.orderDate = '';
		this.purchaseOrderID = 0;
		this.revisionNumber = 0;
		this.shipDate = '';
		this.shipMethodID = 0;
		this.status = 0;
		this.subTotal = 0;
		this.taxAmt = 0;
		this.totalDue = 0;
		this.vendorID = 0;
	}
}

export class ApiPurchaseOrderHeaderClientResponseModel {
	employeeID : number;
	freight : number;
	modifiedDate : string;
	orderDate : string;
	purchaseOrderID : number;
	revisionNumber : number;
	shipDate : string;
	shipMethodID : number;
	status : number;
	subTotal : number;
	taxAmt : number;
	totalDue : number;
	vendorID : number;

	constructor() {
		this.employeeID = 0;
		this.freight = 0;
		this.modifiedDate = '';
		this.orderDate = '';
		this.purchaseOrderID = 0;
		this.revisionNumber = 0;
		this.shipDate = '';
		this.shipMethodID = 0;
		this.status = 0;
		this.subTotal = 0;
		this.taxAmt = 0;
		this.totalDue = 0;
		this.vendorID = 0;
	}
}
export class ApiShipMethodClientRequestModel {
	modifiedDate : string;
	name : string;
	rowguid : string;
	shipBase : number;
	shipMethodID : number;
	shipRate : number;

	constructor() {
		this.modifiedDate = '';
		this.name = '';
		this.rowguid = '';
		this.shipBase = 0;
		this.shipMethodID = 0;
		this.shipRate = 0;
	}
}

export class ApiShipMethodClientResponseModel {
	modifiedDate : string;
	name : string;
	rowguid : string;
	shipBase : number;
	shipMethodID : number;
	shipRate : number;

	constructor() {
		this.modifiedDate = '';
		this.name = '';
		this.rowguid = '';
		this.shipBase = 0;
		this.shipMethodID = 0;
		this.shipRate = 0;
	}
}
export class ApiVendorClientRequestModel {
	accountNumber : string;
	activeFlag : boolean;
	businessEntityID : number;
	creditRating : number;
	modifiedDate : string;
	name : string;
	preferredVendorStatu : boolean;
	purchasingWebServiceURL : string;

	constructor() {
		this.accountNumber = '';
		this.activeFlag = false;
		this.businessEntityID = 0;
		this.creditRating = 0;
		this.modifiedDate = '';
		this.name = '';
		this.preferredVendorStatu = false;
		this.purchasingWebServiceURL = '';
	}
}

export class ApiVendorClientResponseModel {
	accountNumber : string;
	activeFlag : boolean;
	businessEntityID : number;
	creditRating : number;
	modifiedDate : string;
	name : string;
	preferredVendorStatu : boolean;
	purchasingWebServiceURL : string;

	constructor() {
		this.accountNumber = '';
		this.activeFlag = false;
		this.businessEntityID = 0;
		this.creditRating = 0;
		this.modifiedDate = '';
		this.name = '';
		this.preferredVendorStatu = false;
		this.purchasingWebServiceURL = '';
	}
}
export class ApiCreditCardClientRequestModel {
	cardNumber : string;
	cardType : string;
	creditCardID : number;
	expMonth : number;
	expYear : number;
	modifiedDate : string;

	constructor() {
		this.cardNumber = '';
		this.cardType = '';
		this.creditCardID = 0;
		this.expMonth = 0;
		this.expYear = 0;
		this.modifiedDate = '';
	}
}

export class ApiCreditCardClientResponseModel {
	cardNumber : string;
	cardType : string;
	creditCardID : number;
	expMonth : number;
	expYear : number;
	modifiedDate : string;

	constructor() {
		this.cardNumber = '';
		this.cardType = '';
		this.creditCardID = 0;
		this.expMonth = 0;
		this.expYear = 0;
		this.modifiedDate = '';
	}
}
export class ApiCurrencyClientRequestModel {
	currencyCode : string;
	modifiedDate : string;
	name : string;

	constructor() {
		this.currencyCode = '';
		this.modifiedDate = '';
		this.name = '';
	}
}

export class ApiCurrencyClientResponseModel {
	currencyCode : string;
	modifiedDate : string;
	name : string;

	constructor() {
		this.currencyCode = '';
		this.modifiedDate = '';
		this.name = '';
	}
}
export class ApiCurrencyRateClientRequestModel {
	averageRate : number;
	currencyRateDate : string;
	currencyRateID : number;
	endOfDayRate : number;
	fromCurrencyCode : string;
	fromCurrencyCodeEntity : string;
	modifiedDate : string;
	toCurrencyCode : string;
	toCurrencyCodeEntity : string;

	constructor() {
		this.averageRate = 0;
		this.currencyRateDate = '';
		this.currencyRateID = 0;
		this.endOfDayRate = 0;
		this.fromCurrencyCode = '';
		this.fromCurrencyCodeEntity = '';
		this.modifiedDate = '';
		this.toCurrencyCode = '';
		this.toCurrencyCodeEntity = '';
	}
}

export class ApiCurrencyRateClientResponseModel {
	averageRate : number;
	currencyRateDate : string;
	currencyRateID : number;
	endOfDayRate : number;
	fromCurrencyCode : string;
	fromCurrencyCodeEntity : string;
	modifiedDate : string;
	toCurrencyCode : string;
	toCurrencyCodeEntity : string;

	constructor() {
		this.averageRate = 0;
		this.currencyRateDate = '';
		this.currencyRateID = 0;
		this.endOfDayRate = 0;
		this.fromCurrencyCode = '';
		this.fromCurrencyCodeEntity = '';
		this.modifiedDate = '';
		this.toCurrencyCode = '';
		this.toCurrencyCodeEntity = '';
	}
}
export class ApiCustomerClientRequestModel {
	accountNumber : string;
	customerID : number;
	modifiedDate : string;
	personID : number;
	rowguid : string;
	storeID : number;
	storeIDEntity : string;
	territoryID : number;
	territoryIDEntity : string;

	constructor() {
		this.accountNumber = '';
		this.customerID = 0;
		this.modifiedDate = '';
		this.personID = 0;
		this.rowguid = '';
		this.storeID = 0;
		this.storeIDEntity = '';
		this.territoryID = 0;
		this.territoryIDEntity = '';
	}
}

export class ApiCustomerClientResponseModel {
	accountNumber : string;
	customerID : number;
	modifiedDate : string;
	personID : number;
	rowguid : string;
	storeID : number;
	storeIDEntity : string;
	territoryID : number;
	territoryIDEntity : string;

	constructor() {
		this.accountNumber = '';
		this.customerID = 0;
		this.modifiedDate = '';
		this.personID = 0;
		this.rowguid = '';
		this.storeID = 0;
		this.storeIDEntity = '';
		this.territoryID = 0;
		this.territoryIDEntity = '';
	}
}
export class ApiSalesOrderHeaderClientRequestModel {
	accountNumber : string;
	billToAddressID : number;
	comment : string;
	creditCardApprovalCode : string;
	creditCardID : number;
	creditCardIDEntity : string;
	currencyRateID : number;
	currencyRateIDEntity : string;
	customerID : number;
	customerIDEntity : string;
	dueDate : string;
	freight : number;
	modifiedDate : string;
	onlineOrderFlag : boolean;
	orderDate : string;
	purchaseOrderNumber : string;
	revisionNumber : number;
	rowguid : string;
	salesOrderID : number;
	salesOrderNumber : string;
	salesPersonID : number;
	salesPersonIDEntity : string;
	shipDate : string;
	shipMethodID : number;
	shipToAddressID : number;
	status : number;
	subTotal : number;
	taxAmt : number;
	territoryID : number;
	territoryIDEntity : string;
	totalDue : number;

	constructor() {
		this.accountNumber = '';
		this.billToAddressID = 0;
		this.comment = '';
		this.creditCardApprovalCode = '';
		this.creditCardID = 0;
		this.creditCardIDEntity = '';
		this.currencyRateID = 0;
		this.currencyRateIDEntity = '';
		this.customerID = 0;
		this.customerIDEntity = '';
		this.dueDate = '';
		this.freight = 0;
		this.modifiedDate = '';
		this.onlineOrderFlag = false;
		this.orderDate = '';
		this.purchaseOrderNumber = '';
		this.revisionNumber = 0;
		this.rowguid = '';
		this.salesOrderID = 0;
		this.salesOrderNumber = '';
		this.salesPersonID = 0;
		this.salesPersonIDEntity = '';
		this.shipDate = '';
		this.shipMethodID = 0;
		this.shipToAddressID = 0;
		this.status = 0;
		this.subTotal = 0;
		this.taxAmt = 0;
		this.territoryID = 0;
		this.territoryIDEntity = '';
		this.totalDue = 0;
	}
}

export class ApiSalesOrderHeaderClientResponseModel {
	accountNumber : string;
	billToAddressID : number;
	comment : string;
	creditCardApprovalCode : string;
	creditCardID : number;
	creditCardIDEntity : string;
	currencyRateID : number;
	currencyRateIDEntity : string;
	customerID : number;
	customerIDEntity : string;
	dueDate : string;
	freight : number;
	modifiedDate : string;
	onlineOrderFlag : boolean;
	orderDate : string;
	purchaseOrderNumber : string;
	revisionNumber : number;
	rowguid : string;
	salesOrderID : number;
	salesOrderNumber : string;
	salesPersonID : number;
	salesPersonIDEntity : string;
	shipDate : string;
	shipMethodID : number;
	shipToAddressID : number;
	status : number;
	subTotal : number;
	taxAmt : number;
	territoryID : number;
	territoryIDEntity : string;
	totalDue : number;

	constructor() {
		this.accountNumber = '';
		this.billToAddressID = 0;
		this.comment = '';
		this.creditCardApprovalCode = '';
		this.creditCardID = 0;
		this.creditCardIDEntity = '';
		this.currencyRateID = 0;
		this.currencyRateIDEntity = '';
		this.customerID = 0;
		this.customerIDEntity = '';
		this.dueDate = '';
		this.freight = 0;
		this.modifiedDate = '';
		this.onlineOrderFlag = false;
		this.orderDate = '';
		this.purchaseOrderNumber = '';
		this.revisionNumber = 0;
		this.rowguid = '';
		this.salesOrderID = 0;
		this.salesOrderNumber = '';
		this.salesPersonID = 0;
		this.salesPersonIDEntity = '';
		this.shipDate = '';
		this.shipMethodID = 0;
		this.shipToAddressID = 0;
		this.status = 0;
		this.subTotal = 0;
		this.taxAmt = 0;
		this.territoryID = 0;
		this.territoryIDEntity = '';
		this.totalDue = 0;
	}
}
export class ApiSalesPersonClientRequestModel {
	bonus : number;
	businessEntityID : number;
	commissionPct : number;
	modifiedDate : string;
	rowguid : string;
	salesLastYear : number;
	salesQuota : number;
	salesYTD : number;
	territoryID : number;
	territoryIDEntity : string;

	constructor() {
		this.bonus = 0;
		this.businessEntityID = 0;
		this.commissionPct = 0;
		this.modifiedDate = '';
		this.rowguid = '';
		this.salesLastYear = 0;
		this.salesQuota = 0;
		this.salesYTD = 0;
		this.territoryID = 0;
		this.territoryIDEntity = '';
	}
}

export class ApiSalesPersonClientResponseModel {
	bonus : number;
	businessEntityID : number;
	commissionPct : number;
	modifiedDate : string;
	rowguid : string;
	salesLastYear : number;
	salesQuota : number;
	salesYTD : number;
	territoryID : number;
	territoryIDEntity : string;

	constructor() {
		this.bonus = 0;
		this.businessEntityID = 0;
		this.commissionPct = 0;
		this.modifiedDate = '';
		this.rowguid = '';
		this.salesLastYear = 0;
		this.salesQuota = 0;
		this.salesYTD = 0;
		this.territoryID = 0;
		this.territoryIDEntity = '';
	}
}
export class ApiSalesReasonClientRequestModel {
	modifiedDate : string;
	name : string;
	reasonType : string;
	salesReasonID : number;

	constructor() {
		this.modifiedDate = '';
		this.name = '';
		this.reasonType = '';
		this.salesReasonID = 0;
	}
}

export class ApiSalesReasonClientResponseModel {
	modifiedDate : string;
	name : string;
	reasonType : string;
	salesReasonID : number;

	constructor() {
		this.modifiedDate = '';
		this.name = '';
		this.reasonType = '';
		this.salesReasonID = 0;
	}
}
export class ApiSalesTaxRateClientRequestModel {
	modifiedDate : string;
	name : string;
	rowguid : string;
	salesTaxRateID : number;
	stateProvinceID : number;
	taxRate : number;
	taxType : number;

	constructor() {
		this.modifiedDate = '';
		this.name = '';
		this.rowguid = '';
		this.salesTaxRateID = 0;
		this.stateProvinceID = 0;
		this.taxRate = 0;
		this.taxType = 0;
	}
}

export class ApiSalesTaxRateClientResponseModel {
	modifiedDate : string;
	name : string;
	rowguid : string;
	salesTaxRateID : number;
	stateProvinceID : number;
	taxRate : number;
	taxType : number;

	constructor() {
		this.modifiedDate = '';
		this.name = '';
		this.rowguid = '';
		this.salesTaxRateID = 0;
		this.stateProvinceID = 0;
		this.taxRate = 0;
		this.taxType = 0;
	}
}
export class ApiSalesTerritoryClientRequestModel {
	costLastYear : number;
	costYTD : number;
	countryRegionCode : string;
	group : string;
	modifiedDate : string;
	name : string;
	rowguid : string;
	salesLastYear : number;
	salesYTD : number;
	territoryID : number;

	constructor() {
		this.costLastYear = 0;
		this.costYTD = 0;
		this.countryRegionCode = '';
		this.group = '';
		this.modifiedDate = '';
		this.name = '';
		this.rowguid = '';
		this.salesLastYear = 0;
		this.salesYTD = 0;
		this.territoryID = 0;
	}
}

export class ApiSalesTerritoryClientResponseModel {
	costLastYear : number;
	costYTD : number;
	countryRegionCode : string;
	group : string;
	modifiedDate : string;
	name : string;
	rowguid : string;
	salesLastYear : number;
	salesYTD : number;
	territoryID : number;

	constructor() {
		this.costLastYear = 0;
		this.costYTD = 0;
		this.countryRegionCode = '';
		this.group = '';
		this.modifiedDate = '';
		this.name = '';
		this.rowguid = '';
		this.salesLastYear = 0;
		this.salesYTD = 0;
		this.territoryID = 0;
	}
}
export class ApiShoppingCartItemClientRequestModel {
	dateCreated : string;
	modifiedDate : string;
	productID : number;
	quantity : number;
	shoppingCartID : string;
	shoppingCartItemID : number;

	constructor() {
		this.dateCreated = '';
		this.modifiedDate = '';
		this.productID = 0;
		this.quantity = 0;
		this.shoppingCartID = '';
		this.shoppingCartItemID = 0;
	}
}

export class ApiShoppingCartItemClientResponseModel {
	dateCreated : string;
	modifiedDate : string;
	productID : number;
	quantity : number;
	shoppingCartID : string;
	shoppingCartItemID : number;

	constructor() {
		this.dateCreated = '';
		this.modifiedDate = '';
		this.productID = 0;
		this.quantity = 0;
		this.shoppingCartID = '';
		this.shoppingCartItemID = 0;
	}
}
export class ApiSpecialOfferClientRequestModel {
	category : string;
	description : string;
	discountPct : number;
	endDate : string;
	maxQty : number;
	minQty : number;
	modifiedDate : string;
	rowguid : string;
	specialOfferID : number;
	startDate : string;
	type : string;

	constructor() {
		this.category = '';
		this.description = '';
		this.discountPct = 0;
		this.endDate = '';
		this.maxQty = 0;
		this.minQty = 0;
		this.modifiedDate = '';
		this.rowguid = '';
		this.specialOfferID = 0;
		this.startDate = '';
		this.type = '';
	}
}

export class ApiSpecialOfferClientResponseModel {
	category : string;
	description : string;
	discountPct : number;
	endDate : string;
	maxQty : number;
	minQty : number;
	modifiedDate : string;
	rowguid : string;
	specialOfferID : number;
	startDate : string;
	type : string;

	constructor() {
		this.category = '';
		this.description = '';
		this.discountPct = 0;
		this.endDate = '';
		this.maxQty = 0;
		this.minQty = 0;
		this.modifiedDate = '';
		this.rowguid = '';
		this.specialOfferID = 0;
		this.startDate = '';
		this.type = '';
	}
}
export class ApiStoreClientRequestModel {
	businessEntityID : number;
	demographic : string;
	modifiedDate : string;
	name : string;
	rowguid : string;
	salesPersonID : number;
	salesPersonIDEntity : string;

	constructor() {
		this.businessEntityID = 0;
		this.demographic = '';
		this.modifiedDate = '';
		this.name = '';
		this.rowguid = '';
		this.salesPersonID = 0;
		this.salesPersonIDEntity = '';
	}
}

export class ApiStoreClientResponseModel {
	businessEntityID : number;
	demographic : string;
	modifiedDate : string;
	name : string;
	rowguid : string;
	salesPersonID : number;
	salesPersonIDEntity : string;

	constructor() {
		this.businessEntityID = 0;
		this.demographic = '';
		this.modifiedDate = '';
		this.name = '';
		this.rowguid = '';
		this.salesPersonID = 0;
		this.salesPersonIDEntity = '';
	}
}

/*<Codenesium>
    <Hash>a15b57e394735369c5966cf524df2d22</Hash>
</Codenesium>*/