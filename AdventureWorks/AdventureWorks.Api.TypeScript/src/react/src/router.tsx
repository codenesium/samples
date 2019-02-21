import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import { wrapperHeader } from './components/header';
import { ClientRoutes, Constants } from './constants';
import { WrappedAWBuildVersionCreateComponent } from './components/aWBuildVersion/aWBuildVersionCreateForm';
import { WrappedAWBuildVersionDetailComponent } from './components/aWBuildVersion/aWBuildVersionDetailForm';
import { WrappedAWBuildVersionEditComponent } from './components/aWBuildVersion/aWBuildVersionEditForm';
import { WrappedAWBuildVersionSearchComponent } from './components/aWBuildVersion/aWBuildVersionSearchForm';					
import { WrappedDatabaseLogCreateComponent } from './components/databaseLog/databaseLogCreateForm';
import { WrappedDatabaseLogDetailComponent } from './components/databaseLog/databaseLogDetailForm';
import { WrappedDatabaseLogEditComponent } from './components/databaseLog/databaseLogEditForm';
import { WrappedDatabaseLogSearchComponent } from './components/databaseLog/databaseLogSearchForm';					
import { WrappedErrorLogCreateComponent } from './components/errorLog/errorLogCreateForm';
import { WrappedErrorLogDetailComponent } from './components/errorLog/errorLogDetailForm';
import { WrappedErrorLogEditComponent } from './components/errorLog/errorLogEditForm';
import { WrappedErrorLogSearchComponent } from './components/errorLog/errorLogSearchForm';					
import { WrappedDepartmentCreateComponent } from './components/department/departmentCreateForm';
import { WrappedDepartmentDetailComponent } from './components/department/departmentDetailForm';
import { WrappedDepartmentEditComponent } from './components/department/departmentEditForm';
import { WrappedDepartmentSearchComponent } from './components/department/departmentSearchForm';					
import { WrappedEmployeeCreateComponent } from './components/employee/employeeCreateForm';
import { WrappedEmployeeDetailComponent } from './components/employee/employeeDetailForm';
import { WrappedEmployeeEditComponent } from './components/employee/employeeEditForm';
import { WrappedEmployeeSearchComponent } from './components/employee/employeeSearchForm';					
import { WrappedJobCandidateCreateComponent } from './components/jobCandidate/jobCandidateCreateForm';
import { WrappedJobCandidateDetailComponent } from './components/jobCandidate/jobCandidateDetailForm';
import { WrappedJobCandidateEditComponent } from './components/jobCandidate/jobCandidateEditForm';
import { WrappedJobCandidateSearchComponent } from './components/jobCandidate/jobCandidateSearchForm';					
import { WrappedShiftCreateComponent } from './components/shift/shiftCreateForm';
import { WrappedShiftDetailComponent } from './components/shift/shiftDetailForm';
import { WrappedShiftEditComponent } from './components/shift/shiftEditForm';
import { WrappedShiftSearchComponent } from './components/shift/shiftSearchForm';					
import { WrappedAddressCreateComponent } from './components/address/addressCreateForm';
import { WrappedAddressDetailComponent } from './components/address/addressDetailForm';
import { WrappedAddressEditComponent } from './components/address/addressEditForm';
import { WrappedAddressSearchComponent } from './components/address/addressSearchForm';					
import { WrappedAddressTypeCreateComponent } from './components/addressType/addressTypeCreateForm';
import { WrappedAddressTypeDetailComponent } from './components/addressType/addressTypeDetailForm';
import { WrappedAddressTypeEditComponent } from './components/addressType/addressTypeEditForm';
import { WrappedAddressTypeSearchComponent } from './components/addressType/addressTypeSearchForm';					
import { WrappedBusinessEntityCreateComponent } from './components/businessEntity/businessEntityCreateForm';
import { WrappedBusinessEntityDetailComponent } from './components/businessEntity/businessEntityDetailForm';
import { WrappedBusinessEntityEditComponent } from './components/businessEntity/businessEntityEditForm';
import { WrappedBusinessEntitySearchComponent } from './components/businessEntity/businessEntitySearchForm';					
import { WrappedContactTypeCreateComponent } from './components/contactType/contactTypeCreateForm';
import { WrappedContactTypeDetailComponent } from './components/contactType/contactTypeDetailForm';
import { WrappedContactTypeEditComponent } from './components/contactType/contactTypeEditForm';
import { WrappedContactTypeSearchComponent } from './components/contactType/contactTypeSearchForm';					
import { WrappedCountryRegionCreateComponent } from './components/countryRegion/countryRegionCreateForm';
import { WrappedCountryRegionDetailComponent } from './components/countryRegion/countryRegionDetailForm';
import { WrappedCountryRegionEditComponent } from './components/countryRegion/countryRegionEditForm';
import { WrappedCountryRegionSearchComponent } from './components/countryRegion/countryRegionSearchForm';					
import { WrappedPasswordCreateComponent } from './components/password/passwordCreateForm';
import { WrappedPasswordDetailComponent } from './components/password/passwordDetailForm';
import { WrappedPasswordEditComponent } from './components/password/passwordEditForm';
import { WrappedPasswordSearchComponent } from './components/password/passwordSearchForm';					
import { WrappedPersonCreateComponent } from './components/person/personCreateForm';
import { WrappedPersonDetailComponent } from './components/person/personDetailForm';
import { WrappedPersonEditComponent } from './components/person/personEditForm';
import { WrappedPersonSearchComponent } from './components/person/personSearchForm';					
import { WrappedPhoneNumberTypeCreateComponent } from './components/phoneNumberType/phoneNumberTypeCreateForm';
import { WrappedPhoneNumberTypeDetailComponent } from './components/phoneNumberType/phoneNumberTypeDetailForm';
import { WrappedPhoneNumberTypeEditComponent } from './components/phoneNumberType/phoneNumberTypeEditForm';
import { WrappedPhoneNumberTypeSearchComponent } from './components/phoneNumberType/phoneNumberTypeSearchForm';					
import { WrappedStateProvinceCreateComponent } from './components/stateProvince/stateProvinceCreateForm';
import { WrappedStateProvinceDetailComponent } from './components/stateProvince/stateProvinceDetailForm';
import { WrappedStateProvinceEditComponent } from './components/stateProvince/stateProvinceEditForm';
import { WrappedStateProvinceSearchComponent } from './components/stateProvince/stateProvinceSearchForm';					
import { WrappedBillOfMaterialCreateComponent } from './components/billOfMaterial/billOfMaterialCreateForm';
import { WrappedBillOfMaterialDetailComponent } from './components/billOfMaterial/billOfMaterialDetailForm';
import { WrappedBillOfMaterialEditComponent } from './components/billOfMaterial/billOfMaterialEditForm';
import { WrappedBillOfMaterialSearchComponent } from './components/billOfMaterial/billOfMaterialSearchForm';					
import { WrappedCultureCreateComponent } from './components/culture/cultureCreateForm';
import { WrappedCultureDetailComponent } from './components/culture/cultureDetailForm';
import { WrappedCultureEditComponent } from './components/culture/cultureEditForm';
import { WrappedCultureSearchComponent } from './components/culture/cultureSearchForm';					
import { WrappedDocumentCreateComponent } from './components/document/documentCreateForm';
import { WrappedDocumentDetailComponent } from './components/document/documentDetailForm';
import { WrappedDocumentEditComponent } from './components/document/documentEditForm';
import { WrappedDocumentSearchComponent } from './components/document/documentSearchForm';					
import { WrappedIllustrationCreateComponent } from './components/illustration/illustrationCreateForm';
import { WrappedIllustrationDetailComponent } from './components/illustration/illustrationDetailForm';
import { WrappedIllustrationEditComponent } from './components/illustration/illustrationEditForm';
import { WrappedIllustrationSearchComponent } from './components/illustration/illustrationSearchForm';					
import { WrappedLocationCreateComponent } from './components/location/locationCreateForm';
import { WrappedLocationDetailComponent } from './components/location/locationDetailForm';
import { WrappedLocationEditComponent } from './components/location/locationEditForm';
import { WrappedLocationSearchComponent } from './components/location/locationSearchForm';					
import { WrappedProductCreateComponent } from './components/product/productCreateForm';
import { WrappedProductDetailComponent } from './components/product/productDetailForm';
import { WrappedProductEditComponent } from './components/product/productEditForm';
import { WrappedProductSearchComponent } from './components/product/productSearchForm';					
import { WrappedProductCategoryCreateComponent } from './components/productCategory/productCategoryCreateForm';
import { WrappedProductCategoryDetailComponent } from './components/productCategory/productCategoryDetailForm';
import { WrappedProductCategoryEditComponent } from './components/productCategory/productCategoryEditForm';
import { WrappedProductCategorySearchComponent } from './components/productCategory/productCategorySearchForm';					
import { WrappedProductDescriptionCreateComponent } from './components/productDescription/productDescriptionCreateForm';
import { WrappedProductDescriptionDetailComponent } from './components/productDescription/productDescriptionDetailForm';
import { WrappedProductDescriptionEditComponent } from './components/productDescription/productDescriptionEditForm';
import { WrappedProductDescriptionSearchComponent } from './components/productDescription/productDescriptionSearchForm';					
import { WrappedProductModelCreateComponent } from './components/productModel/productModelCreateForm';
import { WrappedProductModelDetailComponent } from './components/productModel/productModelDetailForm';
import { WrappedProductModelEditComponent } from './components/productModel/productModelEditForm';
import { WrappedProductModelSearchComponent } from './components/productModel/productModelSearchForm';					
import { WrappedProductPhotoCreateComponent } from './components/productPhoto/productPhotoCreateForm';
import { WrappedProductPhotoDetailComponent } from './components/productPhoto/productPhotoDetailForm';
import { WrappedProductPhotoEditComponent } from './components/productPhoto/productPhotoEditForm';
import { WrappedProductPhotoSearchComponent } from './components/productPhoto/productPhotoSearchForm';					
import { WrappedProductReviewCreateComponent } from './components/productReview/productReviewCreateForm';
import { WrappedProductReviewDetailComponent } from './components/productReview/productReviewDetailForm';
import { WrappedProductReviewEditComponent } from './components/productReview/productReviewEditForm';
import { WrappedProductReviewSearchComponent } from './components/productReview/productReviewSearchForm';					
import { WrappedProductSubcategoryCreateComponent } from './components/productSubcategory/productSubcategoryCreateForm';
import { WrappedProductSubcategoryDetailComponent } from './components/productSubcategory/productSubcategoryDetailForm';
import { WrappedProductSubcategoryEditComponent } from './components/productSubcategory/productSubcategoryEditForm';
import { WrappedProductSubcategorySearchComponent } from './components/productSubcategory/productSubcategorySearchForm';					
import { WrappedScrapReasonCreateComponent } from './components/scrapReason/scrapReasonCreateForm';
import { WrappedScrapReasonDetailComponent } from './components/scrapReason/scrapReasonDetailForm';
import { WrappedScrapReasonEditComponent } from './components/scrapReason/scrapReasonEditForm';
import { WrappedScrapReasonSearchComponent } from './components/scrapReason/scrapReasonSearchForm';					
import { WrappedTransactionHistoryCreateComponent } from './components/transactionHistory/transactionHistoryCreateForm';
import { WrappedTransactionHistoryDetailComponent } from './components/transactionHistory/transactionHistoryDetailForm';
import { WrappedTransactionHistoryEditComponent } from './components/transactionHistory/transactionHistoryEditForm';
import { WrappedTransactionHistorySearchComponent } from './components/transactionHistory/transactionHistorySearchForm';					
import { WrappedTransactionHistoryArchiveCreateComponent } from './components/transactionHistoryArchive/transactionHistoryArchiveCreateForm';
import { WrappedTransactionHistoryArchiveDetailComponent } from './components/transactionHistoryArchive/transactionHistoryArchiveDetailForm';
import { WrappedTransactionHistoryArchiveEditComponent } from './components/transactionHistoryArchive/transactionHistoryArchiveEditForm';
import { WrappedTransactionHistoryArchiveSearchComponent } from './components/transactionHistoryArchive/transactionHistoryArchiveSearchForm';					
import { WrappedUnitMeasureCreateComponent } from './components/unitMeasure/unitMeasureCreateForm';
import { WrappedUnitMeasureDetailComponent } from './components/unitMeasure/unitMeasureDetailForm';
import { WrappedUnitMeasureEditComponent } from './components/unitMeasure/unitMeasureEditForm';
import { WrappedUnitMeasureSearchComponent } from './components/unitMeasure/unitMeasureSearchForm';					
import { WrappedWorkOrderCreateComponent } from './components/workOrder/workOrderCreateForm';
import { WrappedWorkOrderDetailComponent } from './components/workOrder/workOrderDetailForm';
import { WrappedWorkOrderEditComponent } from './components/workOrder/workOrderEditForm';
import { WrappedWorkOrderSearchComponent } from './components/workOrder/workOrderSearchForm';					
import { WrappedPurchaseOrderHeaderCreateComponent } from './components/purchaseOrderHeader/purchaseOrderHeaderCreateForm';
import { WrappedPurchaseOrderHeaderDetailComponent } from './components/purchaseOrderHeader/purchaseOrderHeaderDetailForm';
import { WrappedPurchaseOrderHeaderEditComponent } from './components/purchaseOrderHeader/purchaseOrderHeaderEditForm';
import { WrappedPurchaseOrderHeaderSearchComponent } from './components/purchaseOrderHeader/purchaseOrderHeaderSearchForm';					
import { WrappedShipMethodCreateComponent } from './components/shipMethod/shipMethodCreateForm';
import { WrappedShipMethodDetailComponent } from './components/shipMethod/shipMethodDetailForm';
import { WrappedShipMethodEditComponent } from './components/shipMethod/shipMethodEditForm';
import { WrappedShipMethodSearchComponent } from './components/shipMethod/shipMethodSearchForm';					
import { WrappedVendorCreateComponent } from './components/vendor/vendorCreateForm';
import { WrappedVendorDetailComponent } from './components/vendor/vendorDetailForm';
import { WrappedVendorEditComponent } from './components/vendor/vendorEditForm';
import { WrappedVendorSearchComponent } from './components/vendor/vendorSearchForm';					
import { WrappedCreditCardCreateComponent } from './components/creditCard/creditCardCreateForm';
import { WrappedCreditCardDetailComponent } from './components/creditCard/creditCardDetailForm';
import { WrappedCreditCardEditComponent } from './components/creditCard/creditCardEditForm';
import { WrappedCreditCardSearchComponent } from './components/creditCard/creditCardSearchForm';					
import { WrappedCurrencyCreateComponent } from './components/currency/currencyCreateForm';
import { WrappedCurrencyDetailComponent } from './components/currency/currencyDetailForm';
import { WrappedCurrencyEditComponent } from './components/currency/currencyEditForm';
import { WrappedCurrencySearchComponent } from './components/currency/currencySearchForm';					
import { WrappedCurrencyRateCreateComponent } from './components/currencyRate/currencyRateCreateForm';
import { WrappedCurrencyRateDetailComponent } from './components/currencyRate/currencyRateDetailForm';
import { WrappedCurrencyRateEditComponent } from './components/currencyRate/currencyRateEditForm';
import { WrappedCurrencyRateSearchComponent } from './components/currencyRate/currencyRateSearchForm';					
import { WrappedCustomerCreateComponent } from './components/customer/customerCreateForm';
import { WrappedCustomerDetailComponent } from './components/customer/customerDetailForm';
import { WrappedCustomerEditComponent } from './components/customer/customerEditForm';
import { WrappedCustomerSearchComponent } from './components/customer/customerSearchForm';					
import { WrappedSalesOrderHeaderCreateComponent } from './components/salesOrderHeader/salesOrderHeaderCreateForm';
import { WrappedSalesOrderHeaderDetailComponent } from './components/salesOrderHeader/salesOrderHeaderDetailForm';
import { WrappedSalesOrderHeaderEditComponent } from './components/salesOrderHeader/salesOrderHeaderEditForm';
import { WrappedSalesOrderHeaderSearchComponent } from './components/salesOrderHeader/salesOrderHeaderSearchForm';					
import { WrappedSalesPersonCreateComponent } from './components/salesPerson/salesPersonCreateForm';
import { WrappedSalesPersonDetailComponent } from './components/salesPerson/salesPersonDetailForm';
import { WrappedSalesPersonEditComponent } from './components/salesPerson/salesPersonEditForm';
import { WrappedSalesPersonSearchComponent } from './components/salesPerson/salesPersonSearchForm';					
import { WrappedSalesReasonCreateComponent } from './components/salesReason/salesReasonCreateForm';
import { WrappedSalesReasonDetailComponent } from './components/salesReason/salesReasonDetailForm';
import { WrappedSalesReasonEditComponent } from './components/salesReason/salesReasonEditForm';
import { WrappedSalesReasonSearchComponent } from './components/salesReason/salesReasonSearchForm';					
import { WrappedSalesTaxRateCreateComponent } from './components/salesTaxRate/salesTaxRateCreateForm';
import { WrappedSalesTaxRateDetailComponent } from './components/salesTaxRate/salesTaxRateDetailForm';
import { WrappedSalesTaxRateEditComponent } from './components/salesTaxRate/salesTaxRateEditForm';
import { WrappedSalesTaxRateSearchComponent } from './components/salesTaxRate/salesTaxRateSearchForm';					
import { WrappedSalesTerritoryCreateComponent } from './components/salesTerritory/salesTerritoryCreateForm';
import { WrappedSalesTerritoryDetailComponent } from './components/salesTerritory/salesTerritoryDetailForm';
import { WrappedSalesTerritoryEditComponent } from './components/salesTerritory/salesTerritoryEditForm';
import { WrappedSalesTerritorySearchComponent } from './components/salesTerritory/salesTerritorySearchForm';					
import { WrappedShoppingCartItemCreateComponent } from './components/shoppingCartItem/shoppingCartItemCreateForm';
import { WrappedShoppingCartItemDetailComponent } from './components/shoppingCartItem/shoppingCartItemDetailForm';
import { WrappedShoppingCartItemEditComponent } from './components/shoppingCartItem/shoppingCartItemEditForm';
import { WrappedShoppingCartItemSearchComponent } from './components/shoppingCartItem/shoppingCartItemSearchForm';					
import { WrappedSpecialOfferCreateComponent } from './components/specialOffer/specialOfferCreateForm';
import { WrappedSpecialOfferDetailComponent } from './components/specialOffer/specialOfferDetailForm';
import { WrappedSpecialOfferEditComponent } from './components/specialOffer/specialOfferEditForm';
import { WrappedSpecialOfferSearchComponent } from './components/specialOffer/specialOfferSearchForm';					
import { WrappedStoreCreateComponent } from './components/store/storeCreateForm';
import { WrappedStoreDetailComponent } from './components/store/storeDetailForm';
import { WrappedStoreEditComponent } from './components/store/storeEditForm';
import { WrappedStoreSearchComponent } from './components/store/storeSearchForm';					

const config = {
  oidc: {
    clientId: '<okta_client_id>',
    issuer: 'https://<okta_application_url>/oauth2/default',
    redirectUri: 'https://<your_public_webserver>/implicit/callback',
    scope: 'openid profile email',
  }
}

export const AppRouter: React.StatelessComponent<{}> = () => {
  const query = new URLSearchParams(location.search)

  return (
    <BrowserRouter>   
	<Security issuer={config.oidc.issuer}
        client_id={config.oidc.clientId}
        redirect_uri={config.oidc.redirectUri}>
	    <SecureRoute path="/protected" component={() => '<div>secure route</div>'} />
        <Switch>
          <Route exact path="/" component={wrapperHeader(Dashboard)} />
		  <Route path={ClientRoutes.AWBuildVersions + "/create"} component={wrapperHeader(WrappedAWBuildVersionCreateComponent)} />
                      <Route path={ClientRoutes.AWBuildVersions + "/edit/:id"} component={wrapperHeader(WrappedAWBuildVersionEditComponent)} />
                      <Route path={ClientRoutes.AWBuildVersions + "/:id"} component={wrapperHeader(WrappedAWBuildVersionDetailComponent)} />
                      <Route path={ClientRoutes.AWBuildVersions} component={wrapperHeader(WrappedAWBuildVersionSearchComponent)} />
					<Route path={ClientRoutes.DatabaseLogs + "/create"} component={wrapperHeader(WrappedDatabaseLogCreateComponent)} />
                      <Route path={ClientRoutes.DatabaseLogs + "/edit/:id"} component={wrapperHeader(WrappedDatabaseLogEditComponent)} />
                      <Route path={ClientRoutes.DatabaseLogs + "/:id"} component={wrapperHeader(WrappedDatabaseLogDetailComponent)} />
                      <Route path={ClientRoutes.DatabaseLogs} component={wrapperHeader(WrappedDatabaseLogSearchComponent)} />
					<Route path={ClientRoutes.ErrorLogs + "/create"} component={wrapperHeader(WrappedErrorLogCreateComponent)} />
                      <Route path={ClientRoutes.ErrorLogs + "/edit/:id"} component={wrapperHeader(WrappedErrorLogEditComponent)} />
                      <Route path={ClientRoutes.ErrorLogs + "/:id"} component={wrapperHeader(WrappedErrorLogDetailComponent)} />
                      <Route path={ClientRoutes.ErrorLogs} component={wrapperHeader(WrappedErrorLogSearchComponent)} />
					<Route path={ClientRoutes.Departments + "/create"} component={wrapperHeader(WrappedDepartmentCreateComponent)} />
                      <Route path={ClientRoutes.Departments + "/edit/:id"} component={wrapperHeader(WrappedDepartmentEditComponent)} />
                      <Route path={ClientRoutes.Departments + "/:id"} component={wrapperHeader(WrappedDepartmentDetailComponent)} />
                      <Route path={ClientRoutes.Departments} component={wrapperHeader(WrappedDepartmentSearchComponent)} />
					<Route path={ClientRoutes.Employees + "/create"} component={wrapperHeader(WrappedEmployeeCreateComponent)} />
                      <Route path={ClientRoutes.Employees + "/edit/:id"} component={wrapperHeader(WrappedEmployeeEditComponent)} />
                      <Route path={ClientRoutes.Employees + "/:id"} component={wrapperHeader(WrappedEmployeeDetailComponent)} />
                      <Route path={ClientRoutes.Employees} component={wrapperHeader(WrappedEmployeeSearchComponent)} />
					<Route path={ClientRoutes.JobCandidates + "/create"} component={wrapperHeader(WrappedJobCandidateCreateComponent)} />
                      <Route path={ClientRoutes.JobCandidates + "/edit/:id"} component={wrapperHeader(WrappedJobCandidateEditComponent)} />
                      <Route path={ClientRoutes.JobCandidates + "/:id"} component={wrapperHeader(WrappedJobCandidateDetailComponent)} />
                      <Route path={ClientRoutes.JobCandidates} component={wrapperHeader(WrappedJobCandidateSearchComponent)} />
					<Route path={ClientRoutes.Shifts + "/create"} component={wrapperHeader(WrappedShiftCreateComponent)} />
                      <Route path={ClientRoutes.Shifts + "/edit/:id"} component={wrapperHeader(WrappedShiftEditComponent)} />
                      <Route path={ClientRoutes.Shifts + "/:id"} component={wrapperHeader(WrappedShiftDetailComponent)} />
                      <Route path={ClientRoutes.Shifts} component={wrapperHeader(WrappedShiftSearchComponent)} />
					<Route path={ClientRoutes.Addresses + "/create"} component={wrapperHeader(WrappedAddressCreateComponent)} />
                      <Route path={ClientRoutes.Addresses + "/edit/:id"} component={wrapperHeader(WrappedAddressEditComponent)} />
                      <Route path={ClientRoutes.Addresses + "/:id"} component={wrapperHeader(WrappedAddressDetailComponent)} />
                      <Route path={ClientRoutes.Addresses} component={wrapperHeader(WrappedAddressSearchComponent)} />
					<Route path={ClientRoutes.AddressTypes + "/create"} component={wrapperHeader(WrappedAddressTypeCreateComponent)} />
                      <Route path={ClientRoutes.AddressTypes + "/edit/:id"} component={wrapperHeader(WrappedAddressTypeEditComponent)} />
                      <Route path={ClientRoutes.AddressTypes + "/:id"} component={wrapperHeader(WrappedAddressTypeDetailComponent)} />
                      <Route path={ClientRoutes.AddressTypes} component={wrapperHeader(WrappedAddressTypeSearchComponent)} />
					<Route path={ClientRoutes.BusinessEntities + "/create"} component={wrapperHeader(WrappedBusinessEntityCreateComponent)} />
                      <Route path={ClientRoutes.BusinessEntities + "/edit/:id"} component={wrapperHeader(WrappedBusinessEntityEditComponent)} />
                      <Route path={ClientRoutes.BusinessEntities + "/:id"} component={wrapperHeader(WrappedBusinessEntityDetailComponent)} />
                      <Route path={ClientRoutes.BusinessEntities} component={wrapperHeader(WrappedBusinessEntitySearchComponent)} />
					<Route path={ClientRoutes.ContactTypes + "/create"} component={wrapperHeader(WrappedContactTypeCreateComponent)} />
                      <Route path={ClientRoutes.ContactTypes + "/edit/:id"} component={wrapperHeader(WrappedContactTypeEditComponent)} />
                      <Route path={ClientRoutes.ContactTypes + "/:id"} component={wrapperHeader(WrappedContactTypeDetailComponent)} />
                      <Route path={ClientRoutes.ContactTypes} component={wrapperHeader(WrappedContactTypeSearchComponent)} />
					<Route path={ClientRoutes.CountryRegions + "/create"} component={wrapperHeader(WrappedCountryRegionCreateComponent)} />
                      <Route path={ClientRoutes.CountryRegions + "/edit/:id"} component={wrapperHeader(WrappedCountryRegionEditComponent)} />
                      <Route path={ClientRoutes.CountryRegions + "/:id"} component={wrapperHeader(WrappedCountryRegionDetailComponent)} />
                      <Route path={ClientRoutes.CountryRegions} component={wrapperHeader(WrappedCountryRegionSearchComponent)} />
					<Route path={ClientRoutes.Passwords + "/create"} component={wrapperHeader(WrappedPasswordCreateComponent)} />
                      <Route path={ClientRoutes.Passwords + "/edit/:id"} component={wrapperHeader(WrappedPasswordEditComponent)} />
                      <Route path={ClientRoutes.Passwords + "/:id"} component={wrapperHeader(WrappedPasswordDetailComponent)} />
                      <Route path={ClientRoutes.Passwords} component={wrapperHeader(WrappedPasswordSearchComponent)} />
					<Route path={ClientRoutes.People + "/create"} component={wrapperHeader(WrappedPersonCreateComponent)} />
                      <Route path={ClientRoutes.People + "/edit/:id"} component={wrapperHeader(WrappedPersonEditComponent)} />
                      <Route path={ClientRoutes.People + "/:id"} component={wrapperHeader(WrappedPersonDetailComponent)} />
                      <Route path={ClientRoutes.People} component={wrapperHeader(WrappedPersonSearchComponent)} />
					<Route path={ClientRoutes.PhoneNumberTypes + "/create"} component={wrapperHeader(WrappedPhoneNumberTypeCreateComponent)} />
                      <Route path={ClientRoutes.PhoneNumberTypes + "/edit/:id"} component={wrapperHeader(WrappedPhoneNumberTypeEditComponent)} />
                      <Route path={ClientRoutes.PhoneNumberTypes + "/:id"} component={wrapperHeader(WrappedPhoneNumberTypeDetailComponent)} />
                      <Route path={ClientRoutes.PhoneNumberTypes} component={wrapperHeader(WrappedPhoneNumberTypeSearchComponent)} />
					<Route path={ClientRoutes.StateProvinces + "/create"} component={wrapperHeader(WrappedStateProvinceCreateComponent)} />
                      <Route path={ClientRoutes.StateProvinces + "/edit/:id"} component={wrapperHeader(WrappedStateProvinceEditComponent)} />
                      <Route path={ClientRoutes.StateProvinces + "/:id"} component={wrapperHeader(WrappedStateProvinceDetailComponent)} />
                      <Route path={ClientRoutes.StateProvinces} component={wrapperHeader(WrappedStateProvinceSearchComponent)} />
					<Route path={ClientRoutes.BillOfMaterials + "/create"} component={wrapperHeader(WrappedBillOfMaterialCreateComponent)} />
                      <Route path={ClientRoutes.BillOfMaterials + "/edit/:id"} component={wrapperHeader(WrappedBillOfMaterialEditComponent)} />
                      <Route path={ClientRoutes.BillOfMaterials + "/:id"} component={wrapperHeader(WrappedBillOfMaterialDetailComponent)} />
                      <Route path={ClientRoutes.BillOfMaterials} component={wrapperHeader(WrappedBillOfMaterialSearchComponent)} />
					<Route path={ClientRoutes.Cultures + "/create"} component={wrapperHeader(WrappedCultureCreateComponent)} />
                      <Route path={ClientRoutes.Cultures + "/edit/:id"} component={wrapperHeader(WrappedCultureEditComponent)} />
                      <Route path={ClientRoutes.Cultures + "/:id"} component={wrapperHeader(WrappedCultureDetailComponent)} />
                      <Route path={ClientRoutes.Cultures} component={wrapperHeader(WrappedCultureSearchComponent)} />
					<Route path={ClientRoutes.Documents + "/create"} component={wrapperHeader(WrappedDocumentCreateComponent)} />
                      <Route path={ClientRoutes.Documents + "/edit/:id"} component={wrapperHeader(WrappedDocumentEditComponent)} />
                      <Route path={ClientRoutes.Documents + "/:id"} component={wrapperHeader(WrappedDocumentDetailComponent)} />
                      <Route path={ClientRoutes.Documents} component={wrapperHeader(WrappedDocumentSearchComponent)} />
					<Route path={ClientRoutes.Illustrations + "/create"} component={wrapperHeader(WrappedIllustrationCreateComponent)} />
                      <Route path={ClientRoutes.Illustrations + "/edit/:id"} component={wrapperHeader(WrappedIllustrationEditComponent)} />
                      <Route path={ClientRoutes.Illustrations + "/:id"} component={wrapperHeader(WrappedIllustrationDetailComponent)} />
                      <Route path={ClientRoutes.Illustrations} component={wrapperHeader(WrappedIllustrationSearchComponent)} />
					<Route path={ClientRoutes.Locations + "/create"} component={wrapperHeader(WrappedLocationCreateComponent)} />
                      <Route path={ClientRoutes.Locations + "/edit/:id"} component={wrapperHeader(WrappedLocationEditComponent)} />
                      <Route path={ClientRoutes.Locations + "/:id"} component={wrapperHeader(WrappedLocationDetailComponent)} />
                      <Route path={ClientRoutes.Locations} component={wrapperHeader(WrappedLocationSearchComponent)} />
					<Route path={ClientRoutes.Products + "/create"} component={wrapperHeader(WrappedProductCreateComponent)} />
                      <Route path={ClientRoutes.Products + "/edit/:id"} component={wrapperHeader(WrappedProductEditComponent)} />
                      <Route path={ClientRoutes.Products + "/:id"} component={wrapperHeader(WrappedProductDetailComponent)} />
                      <Route path={ClientRoutes.Products} component={wrapperHeader(WrappedProductSearchComponent)} />
					<Route path={ClientRoutes.ProductCategories + "/create"} component={wrapperHeader(WrappedProductCategoryCreateComponent)} />
                      <Route path={ClientRoutes.ProductCategories + "/edit/:id"} component={wrapperHeader(WrappedProductCategoryEditComponent)} />
                      <Route path={ClientRoutes.ProductCategories + "/:id"} component={wrapperHeader(WrappedProductCategoryDetailComponent)} />
                      <Route path={ClientRoutes.ProductCategories} component={wrapperHeader(WrappedProductCategorySearchComponent)} />
					<Route path={ClientRoutes.ProductDescriptions + "/create"} component={wrapperHeader(WrappedProductDescriptionCreateComponent)} />
                      <Route path={ClientRoutes.ProductDescriptions + "/edit/:id"} component={wrapperHeader(WrappedProductDescriptionEditComponent)} />
                      <Route path={ClientRoutes.ProductDescriptions + "/:id"} component={wrapperHeader(WrappedProductDescriptionDetailComponent)} />
                      <Route path={ClientRoutes.ProductDescriptions} component={wrapperHeader(WrappedProductDescriptionSearchComponent)} />
					<Route path={ClientRoutes.ProductModels + "/create"} component={wrapperHeader(WrappedProductModelCreateComponent)} />
                      <Route path={ClientRoutes.ProductModels + "/edit/:id"} component={wrapperHeader(WrappedProductModelEditComponent)} />
                      <Route path={ClientRoutes.ProductModels + "/:id"} component={wrapperHeader(WrappedProductModelDetailComponent)} />
                      <Route path={ClientRoutes.ProductModels} component={wrapperHeader(WrappedProductModelSearchComponent)} />
					<Route path={ClientRoutes.ProductPhotoes + "/create"} component={wrapperHeader(WrappedProductPhotoCreateComponent)} />
                      <Route path={ClientRoutes.ProductPhotoes + "/edit/:id"} component={wrapperHeader(WrappedProductPhotoEditComponent)} />
                      <Route path={ClientRoutes.ProductPhotoes + "/:id"} component={wrapperHeader(WrappedProductPhotoDetailComponent)} />
                      <Route path={ClientRoutes.ProductPhotoes} component={wrapperHeader(WrappedProductPhotoSearchComponent)} />
					<Route path={ClientRoutes.ProductReviews + "/create"} component={wrapperHeader(WrappedProductReviewCreateComponent)} />
                      <Route path={ClientRoutes.ProductReviews + "/edit/:id"} component={wrapperHeader(WrappedProductReviewEditComponent)} />
                      <Route path={ClientRoutes.ProductReviews + "/:id"} component={wrapperHeader(WrappedProductReviewDetailComponent)} />
                      <Route path={ClientRoutes.ProductReviews} component={wrapperHeader(WrappedProductReviewSearchComponent)} />
					<Route path={ClientRoutes.ProductSubcategories + "/create"} component={wrapperHeader(WrappedProductSubcategoryCreateComponent)} />
                      <Route path={ClientRoutes.ProductSubcategories + "/edit/:id"} component={wrapperHeader(WrappedProductSubcategoryEditComponent)} />
                      <Route path={ClientRoutes.ProductSubcategories + "/:id"} component={wrapperHeader(WrappedProductSubcategoryDetailComponent)} />
                      <Route path={ClientRoutes.ProductSubcategories} component={wrapperHeader(WrappedProductSubcategorySearchComponent)} />
					<Route path={ClientRoutes.ScrapReasons + "/create"} component={wrapperHeader(WrappedScrapReasonCreateComponent)} />
                      <Route path={ClientRoutes.ScrapReasons + "/edit/:id"} component={wrapperHeader(WrappedScrapReasonEditComponent)} />
                      <Route path={ClientRoutes.ScrapReasons + "/:id"} component={wrapperHeader(WrappedScrapReasonDetailComponent)} />
                      <Route path={ClientRoutes.ScrapReasons} component={wrapperHeader(WrappedScrapReasonSearchComponent)} />
					<Route path={ClientRoutes.TransactionHistories + "/create"} component={wrapperHeader(WrappedTransactionHistoryCreateComponent)} />
                      <Route path={ClientRoutes.TransactionHistories + "/edit/:id"} component={wrapperHeader(WrappedTransactionHistoryEditComponent)} />
                      <Route path={ClientRoutes.TransactionHistories + "/:id"} component={wrapperHeader(WrappedTransactionHistoryDetailComponent)} />
                      <Route path={ClientRoutes.TransactionHistories} component={wrapperHeader(WrappedTransactionHistorySearchComponent)} />
					<Route path={ClientRoutes.TransactionHistoryArchives + "/create"} component={wrapperHeader(WrappedTransactionHistoryArchiveCreateComponent)} />
                      <Route path={ClientRoutes.TransactionHistoryArchives + "/edit/:id"} component={wrapperHeader(WrappedTransactionHistoryArchiveEditComponent)} />
                      <Route path={ClientRoutes.TransactionHistoryArchives + "/:id"} component={wrapperHeader(WrappedTransactionHistoryArchiveDetailComponent)} />
                      <Route path={ClientRoutes.TransactionHistoryArchives} component={wrapperHeader(WrappedTransactionHistoryArchiveSearchComponent)} />
					<Route path={ClientRoutes.UnitMeasures + "/create"} component={wrapperHeader(WrappedUnitMeasureCreateComponent)} />
                      <Route path={ClientRoutes.UnitMeasures + "/edit/:id"} component={wrapperHeader(WrappedUnitMeasureEditComponent)} />
                      <Route path={ClientRoutes.UnitMeasures + "/:id"} component={wrapperHeader(WrappedUnitMeasureDetailComponent)} />
                      <Route path={ClientRoutes.UnitMeasures} component={wrapperHeader(WrappedUnitMeasureSearchComponent)} />
					<Route path={ClientRoutes.WorkOrders + "/create"} component={wrapperHeader(WrappedWorkOrderCreateComponent)} />
                      <Route path={ClientRoutes.WorkOrders + "/edit/:id"} component={wrapperHeader(WrappedWorkOrderEditComponent)} />
                      <Route path={ClientRoutes.WorkOrders + "/:id"} component={wrapperHeader(WrappedWorkOrderDetailComponent)} />
                      <Route path={ClientRoutes.WorkOrders} component={wrapperHeader(WrappedWorkOrderSearchComponent)} />
					<Route path={ClientRoutes.PurchaseOrderHeaders + "/create"} component={wrapperHeader(WrappedPurchaseOrderHeaderCreateComponent)} />
                      <Route path={ClientRoutes.PurchaseOrderHeaders + "/edit/:id"} component={wrapperHeader(WrappedPurchaseOrderHeaderEditComponent)} />
                      <Route path={ClientRoutes.PurchaseOrderHeaders + "/:id"} component={wrapperHeader(WrappedPurchaseOrderHeaderDetailComponent)} />
                      <Route path={ClientRoutes.PurchaseOrderHeaders} component={wrapperHeader(WrappedPurchaseOrderHeaderSearchComponent)} />
					<Route path={ClientRoutes.ShipMethods + "/create"} component={wrapperHeader(WrappedShipMethodCreateComponent)} />
                      <Route path={ClientRoutes.ShipMethods + "/edit/:id"} component={wrapperHeader(WrappedShipMethodEditComponent)} />
                      <Route path={ClientRoutes.ShipMethods + "/:id"} component={wrapperHeader(WrappedShipMethodDetailComponent)} />
                      <Route path={ClientRoutes.ShipMethods} component={wrapperHeader(WrappedShipMethodSearchComponent)} />
					<Route path={ClientRoutes.Vendors + "/create"} component={wrapperHeader(WrappedVendorCreateComponent)} />
                      <Route path={ClientRoutes.Vendors + "/edit/:id"} component={wrapperHeader(WrappedVendorEditComponent)} />
                      <Route path={ClientRoutes.Vendors + "/:id"} component={wrapperHeader(WrappedVendorDetailComponent)} />
                      <Route path={ClientRoutes.Vendors} component={wrapperHeader(WrappedVendorSearchComponent)} />
					<Route path={ClientRoutes.CreditCards + "/create"} component={wrapperHeader(WrappedCreditCardCreateComponent)} />
                      <Route path={ClientRoutes.CreditCards + "/edit/:id"} component={wrapperHeader(WrappedCreditCardEditComponent)} />
                      <Route path={ClientRoutes.CreditCards + "/:id"} component={wrapperHeader(WrappedCreditCardDetailComponent)} />
                      <Route path={ClientRoutes.CreditCards} component={wrapperHeader(WrappedCreditCardSearchComponent)} />
					<Route path={ClientRoutes.Currencies + "/create"} component={wrapperHeader(WrappedCurrencyCreateComponent)} />
                      <Route path={ClientRoutes.Currencies + "/edit/:id"} component={wrapperHeader(WrappedCurrencyEditComponent)} />
                      <Route path={ClientRoutes.Currencies + "/:id"} component={wrapperHeader(WrappedCurrencyDetailComponent)} />
                      <Route path={ClientRoutes.Currencies} component={wrapperHeader(WrappedCurrencySearchComponent)} />
					<Route path={ClientRoutes.CurrencyRates + "/create"} component={wrapperHeader(WrappedCurrencyRateCreateComponent)} />
                      <Route path={ClientRoutes.CurrencyRates + "/edit/:id"} component={wrapperHeader(WrappedCurrencyRateEditComponent)} />
                      <Route path={ClientRoutes.CurrencyRates + "/:id"} component={wrapperHeader(WrappedCurrencyRateDetailComponent)} />
                      <Route path={ClientRoutes.CurrencyRates} component={wrapperHeader(WrappedCurrencyRateSearchComponent)} />
					<Route path={ClientRoutes.Customers + "/create"} component={wrapperHeader(WrappedCustomerCreateComponent)} />
                      <Route path={ClientRoutes.Customers + "/edit/:id"} component={wrapperHeader(WrappedCustomerEditComponent)} />
                      <Route path={ClientRoutes.Customers + "/:id"} component={wrapperHeader(WrappedCustomerDetailComponent)} />
                      <Route path={ClientRoutes.Customers} component={wrapperHeader(WrappedCustomerSearchComponent)} />
					<Route path={ClientRoutes.SalesOrderHeaders + "/create"} component={wrapperHeader(WrappedSalesOrderHeaderCreateComponent)} />
                      <Route path={ClientRoutes.SalesOrderHeaders + "/edit/:id"} component={wrapperHeader(WrappedSalesOrderHeaderEditComponent)} />
                      <Route path={ClientRoutes.SalesOrderHeaders + "/:id"} component={wrapperHeader(WrappedSalesOrderHeaderDetailComponent)} />
                      <Route path={ClientRoutes.SalesOrderHeaders} component={wrapperHeader(WrappedSalesOrderHeaderSearchComponent)} />
					<Route path={ClientRoutes.SalesPersons + "/create"} component={wrapperHeader(WrappedSalesPersonCreateComponent)} />
                      <Route path={ClientRoutes.SalesPersons + "/edit/:id"} component={wrapperHeader(WrappedSalesPersonEditComponent)} />
                      <Route path={ClientRoutes.SalesPersons + "/:id"} component={wrapperHeader(WrappedSalesPersonDetailComponent)} />
                      <Route path={ClientRoutes.SalesPersons} component={wrapperHeader(WrappedSalesPersonSearchComponent)} />
					<Route path={ClientRoutes.SalesReasons + "/create"} component={wrapperHeader(WrappedSalesReasonCreateComponent)} />
                      <Route path={ClientRoutes.SalesReasons + "/edit/:id"} component={wrapperHeader(WrappedSalesReasonEditComponent)} />
                      <Route path={ClientRoutes.SalesReasons + "/:id"} component={wrapperHeader(WrappedSalesReasonDetailComponent)} />
                      <Route path={ClientRoutes.SalesReasons} component={wrapperHeader(WrappedSalesReasonSearchComponent)} />
					<Route path={ClientRoutes.SalesTaxRates + "/create"} component={wrapperHeader(WrappedSalesTaxRateCreateComponent)} />
                      <Route path={ClientRoutes.SalesTaxRates + "/edit/:id"} component={wrapperHeader(WrappedSalesTaxRateEditComponent)} />
                      <Route path={ClientRoutes.SalesTaxRates + "/:id"} component={wrapperHeader(WrappedSalesTaxRateDetailComponent)} />
                      <Route path={ClientRoutes.SalesTaxRates} component={wrapperHeader(WrappedSalesTaxRateSearchComponent)} />
					<Route path={ClientRoutes.SalesTerritories + "/create"} component={wrapperHeader(WrappedSalesTerritoryCreateComponent)} />
                      <Route path={ClientRoutes.SalesTerritories + "/edit/:id"} component={wrapperHeader(WrappedSalesTerritoryEditComponent)} />
                      <Route path={ClientRoutes.SalesTerritories + "/:id"} component={wrapperHeader(WrappedSalesTerritoryDetailComponent)} />
                      <Route path={ClientRoutes.SalesTerritories} component={wrapperHeader(WrappedSalesTerritorySearchComponent)} />
					<Route path={ClientRoutes.ShoppingCartItems + "/create"} component={wrapperHeader(WrappedShoppingCartItemCreateComponent)} />
                      <Route path={ClientRoutes.ShoppingCartItems + "/edit/:id"} component={wrapperHeader(WrappedShoppingCartItemEditComponent)} />
                      <Route path={ClientRoutes.ShoppingCartItems + "/:id"} component={wrapperHeader(WrappedShoppingCartItemDetailComponent)} />
                      <Route path={ClientRoutes.ShoppingCartItems} component={wrapperHeader(WrappedShoppingCartItemSearchComponent)} />
					<Route path={ClientRoutes.SpecialOffers + "/create"} component={wrapperHeader(WrappedSpecialOfferCreateComponent)} />
                      <Route path={ClientRoutes.SpecialOffers + "/edit/:id"} component={wrapperHeader(WrappedSpecialOfferEditComponent)} />
                      <Route path={ClientRoutes.SpecialOffers + "/:id"} component={wrapperHeader(WrappedSpecialOfferDetailComponent)} />
                      <Route path={ClientRoutes.SpecialOffers} component={wrapperHeader(WrappedSpecialOfferSearchComponent)} />
					<Route path={ClientRoutes.Stores + "/create"} component={wrapperHeader(WrappedStoreCreateComponent)} />
                      <Route path={ClientRoutes.Stores + "/edit/:id"} component={wrapperHeader(WrappedStoreEditComponent)} />
                      <Route path={ClientRoutes.Stores + "/:id"} component={wrapperHeader(WrappedStoreDetailComponent)} />
                      <Route path={ClientRoutes.Stores} component={wrapperHeader(WrappedStoreSearchComponent)} />
					        </Switch>
	  </Security>
    </BrowserRouter>
  );
}

/*<Codenesium>
    <Hash>1accda370d57f6cd8baa51f815383e18</Hash>
</Codenesium>*/