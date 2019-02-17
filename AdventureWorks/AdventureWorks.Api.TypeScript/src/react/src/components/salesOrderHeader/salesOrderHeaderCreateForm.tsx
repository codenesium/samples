import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import SalesOrderHeaderMapper from './salesOrderHeaderMapper';
import SalesOrderHeaderViewModel from './salesOrderHeaderViewModel';

interface Props {
    model?:SalesOrderHeaderViewModel
}

   const SalesOrderHeaderCreateDisplay: React.SFC<FormikProps<SalesOrderHeaderViewModel>> = (props: FormikProps<SalesOrderHeaderViewModel>) => {

   let status = props.status as CreateResponse<Api.SalesOrderHeaderClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof SalesOrderHeaderViewModel]  && props.errors[name as keyof SalesOrderHeaderViewModel]) {
            response += props.errors[name as keyof SalesOrderHeaderViewModel];
        }

        if(status && status.validationErrors && status.validationErrors.find(f => f.propertyName.toLowerCase() == name.toLowerCase())) {
            response += status.validationErrors.filter(f => f.propertyName.toLowerCase() == name.toLowerCase())[0].errorMessage;
        }

        return response;
   }

   let errorExistForField = (name:string) : boolean =>
   {
        return errorsForField(name) != '';
   }

   return (<form onSubmit={props.handleSubmit} role="form">            
            			<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("accountNumber") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>AccountNumber</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="accountNumber" className={errorExistForField("accountNumber") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("accountNumber") && <small className="text-danger">{errorsForField("accountNumber")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("billToAddressID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>BillToAddressID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="billToAddressID" className={errorExistForField("billToAddressID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("billToAddressID") && <small className="text-danger">{errorsForField("billToAddressID")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("comment") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Comment</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="comment" className={errorExistForField("comment") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("comment") && <small className="text-danger">{errorsForField("comment")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("creditCardApprovalCode") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CreditCardApprovalCode</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="creditCardApprovalCode" className={errorExistForField("creditCardApprovalCode") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("creditCardApprovalCode") && <small className="text-danger">{errorsForField("creditCardApprovalCode")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("creditCardID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CreditCardID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="creditCardID" className={errorExistForField("creditCardID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("creditCardID") && <small className="text-danger">{errorsForField("creditCardID")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("currencyRateID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CurrencyRateID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="currencyRateID" className={errorExistForField("currencyRateID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("currencyRateID") && <small className="text-danger">{errorsForField("currencyRateID")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("customerID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CustomerID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="customerID" className={errorExistForField("customerID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("customerID") && <small className="text-danger">{errorsForField("customerID")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("dueDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>DueDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="dueDate" className={errorExistForField("dueDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("dueDate") && <small className="text-danger">{errorsForField("dueDate")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("freight") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Freight</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="freight" className={errorExistForField("freight") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("freight") && <small className="text-danger">{errorsForField("freight")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("modifiedDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ModifiedDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="modifiedDate" className={errorExistForField("modifiedDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("modifiedDate") && <small className="text-danger">{errorsForField("modifiedDate")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("onlineOrderFlag") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>OnlineOrderFlag</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="onlineOrderFlag" className={errorExistForField("onlineOrderFlag") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("onlineOrderFlag") && <small className="text-danger">{errorsForField("onlineOrderFlag")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("orderDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>OrderDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="orderDate" className={errorExistForField("orderDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("orderDate") && <small className="text-danger">{errorsForField("orderDate")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("purchaseOrderNumber") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PurchaseOrderNumber</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="purchaseOrderNumber" className={errorExistForField("purchaseOrderNumber") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("purchaseOrderNumber") && <small className="text-danger">{errorsForField("purchaseOrderNumber")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("revisionNumber") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>RevisionNumber</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="revisionNumber" className={errorExistForField("revisionNumber") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("revisionNumber") && <small className="text-danger">{errorsForField("revisionNumber")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("rowguid") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Rowguid</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="rowguid" className={errorExistForField("rowguid") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("rowguid") && <small className="text-danger">{errorsForField("rowguid")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("salesOrderNumber") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>SalesOrderNumber</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="salesOrderNumber" className={errorExistForField("salesOrderNumber") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("salesOrderNumber") && <small className="text-danger">{errorsForField("salesOrderNumber")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("salesPersonID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>SalesPersonID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="salesPersonID" className={errorExistForField("salesPersonID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("salesPersonID") && <small className="text-danger">{errorsForField("salesPersonID")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("shipDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ShipDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="shipDate" className={errorExistForField("shipDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("shipDate") && <small className="text-danger">{errorsForField("shipDate")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("shipMethodID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ShipMethodID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="shipMethodID" className={errorExistForField("shipMethodID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("shipMethodID") && <small className="text-danger">{errorsForField("shipMethodID")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("shipToAddressID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ShipToAddressID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="shipToAddressID" className={errorExistForField("shipToAddressID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("shipToAddressID") && <small className="text-danger">{errorsForField("shipToAddressID")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("status") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Status</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="status" className={errorExistForField("status") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("status") && <small className="text-danger">{errorsForField("status")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("subTotal") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>SubTotal</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="subTotal" className={errorExistForField("subTotal") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("subTotal") && <small className="text-danger">{errorsForField("subTotal")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("taxAmt") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TaxAmt</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="taxAmt" className={errorExistForField("taxAmt") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("taxAmt") && <small className="text-danger">{errorsForField("taxAmt")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("territoryID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TerritoryID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="territoryID" className={errorExistForField("territoryID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("territoryID") && <small className="text-danger">{errorsForField("territoryID")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("totalDue") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TotalDue</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="totalDue" className={errorExistForField("totalDue") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("totalDue") && <small className="text-danger">{errorsForField("totalDue")}</small>}
                        </div>
                    </div>

			
            <button type="submit" className="btn btn-primary" disabled={false}>
                Submit
            </button>
            <br />
            <br />
            { 
                status && status.success ? (<div className="alert alert-success">Success</div>): (null)
            }
                        
            { 
                status && !status.success ? (<div className="alert alert-danger">Error occurred</div>): (null)
            }
          </form>);
}


const SalesOrderHeaderCreate = withFormik<Props, SalesOrderHeaderViewModel>({
    mapPropsToValues: props => {
                
		let response = new SalesOrderHeaderViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.accountNumber,props.model!.billToAddressID,props.model!.comment,props.model!.creditCardApprovalCode,props.model!.creditCardID,props.model!.currencyRateID,props.model!.customerID,props.model!.dueDate,props.model!.freight,props.model!.modifiedDate,props.model!.onlineOrderFlag,props.model!.orderDate,props.model!.purchaseOrderNumber,props.model!.revisionNumber,props.model!.rowguid,props.model!.salesOrderID,props.model!.salesOrderNumber,props.model!.salesPersonID,props.model!.shipDate,props.model!.shipMethodID,props.model!.shipToAddressID,props.model!.status,props.model!.subTotal,props.model!.taxAmt,props.model!.territoryID,props.model!.totalDue);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<SalesOrderHeaderViewModel> = { };

	  if(values.billToAddressID == 0) {
                errors.billToAddressID = "Required"
                    }if(values.customerID == 0) {
                errors.customerID = "Required"
                    }if(values.dueDate == undefined) {
                errors.dueDate = "Required"
                    }if(values.freight == 0) {
                errors.freight = "Required"
                    }if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.orderDate == undefined) {
                errors.orderDate = "Required"
                    }if(values.revisionNumber == 0) {
                errors.revisionNumber = "Required"
                    }if(values.rowguid == undefined) {
                errors.rowguid = "Required"
                    }if(values.salesOrderNumber == '') {
                errors.salesOrderNumber = "Required"
                    }if(values.shipMethodID == 0) {
                errors.shipMethodID = "Required"
                    }if(values.shipToAddressID == 0) {
                errors.shipToAddressID = "Required"
                    }if(values.status == 0) {
                errors.status = "Required"
                    }if(values.subTotal == 0) {
                errors.subTotal = "Required"
                    }if(values.taxAmt == 0) {
                errors.taxAmt = "Required"
                    }if(values.totalDue == 0) {
                errors.totalDue = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new SalesOrderHeaderMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.SalesOrderHeaders,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.SalesOrderHeaderClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'SalesOrderHeaderCreate', 
  })(SalesOrderHeaderCreateDisplay);

  interface SalesOrderHeaderCreateComponentProps
  {
  }

  interface SalesOrderHeaderCreateComponentState
  {
      model?:SalesOrderHeaderViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class SalesOrderHeaderCreateComponent extends React.Component<SalesOrderHeaderCreateComponentProps, SalesOrderHeaderCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<SalesOrderHeaderCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>9495015b67c268dc7ddd12ab5ab5341e</Hash>
</Codenesium>*/