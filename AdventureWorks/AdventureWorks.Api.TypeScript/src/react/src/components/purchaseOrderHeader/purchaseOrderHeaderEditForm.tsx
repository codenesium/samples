import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import PurchaseOrderHeaderViewModel from './purchaseOrderHeaderViewModel';
import PurchaseOrderHeaderMapper from './purchaseOrderHeaderMapper';

interface Props {
    model?:PurchaseOrderHeaderViewModel
}

  const PurchaseOrderHeaderEditDisplay = (props: FormikProps<PurchaseOrderHeaderViewModel>) => {

   let status = props.status as UpdateResponse<Api.PurchaseOrderHeaderClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof PurchaseOrderHeaderViewModel]  && props.errors[name as keyof PurchaseOrderHeaderViewModel]) {
            response += props.errors[name as keyof PurchaseOrderHeaderViewModel];
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

   return (

          <form onSubmit={props.handleSubmit} role="form">
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("employeeID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>EmployeeID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="employeeID" className={errorExistForField("employeeID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("employeeID") && <small className="text-danger">{errorsForField("employeeID")}</small>}
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
                        <label htmlFor="name" className={errorExistForField("orderDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>OrderDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="orderDate" className={errorExistForField("orderDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("orderDate") && <small className="text-danger">{errorsForField("orderDate")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("purchaseOrderID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PurchaseOrderID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="purchaseOrderID" className={errorExistForField("purchaseOrderID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("purchaseOrderID") && <small className="text-danger">{errorsForField("purchaseOrderID")}</small>}
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
                        <label htmlFor="name" className={errorExistForField("totalDue") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TotalDue</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="totalDue" className={errorExistForField("totalDue") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("totalDue") && <small className="text-danger">{errorsForField("totalDue")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("vendorID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>VendorID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="vendorID" className={errorExistForField("vendorID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("vendorID") && <small className="text-danger">{errorsForField("vendorID")}</small>}
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
          </form>
  );
}


const PurchaseOrderHeaderEdit = withFormik<Props, PurchaseOrderHeaderViewModel>({
    mapPropsToValues: props => {
        let response = new PurchaseOrderHeaderViewModel();
		response.setProperties(props.model!.employeeID,props.model!.freight,props.model!.modifiedDate,props.model!.orderDate,props.model!.purchaseOrderID,props.model!.revisionNumber,props.model!.shipDate,props.model!.shipMethodID,props.model!.status,props.model!.subTotal,props.model!.taxAmt,props.model!.totalDue,props.model!.vendorID);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<PurchaseOrderHeaderViewModel> = { };

	  if(values.employeeID == 0) {
                errors.employeeID = "Required"
                    }if(values.freight == 0) {
                errors.freight = "Required"
                    }if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.orderDate == undefined) {
                errors.orderDate = "Required"
                    }if(values.purchaseOrderID == 0) {
                errors.purchaseOrderID = "Required"
                    }if(values.revisionNumber == 0) {
                errors.revisionNumber = "Required"
                    }if(values.shipMethodID == 0) {
                errors.shipMethodID = "Required"
                    }if(values.status == 0) {
                errors.status = "Required"
                    }if(values.subTotal == 0) {
                errors.subTotal = "Required"
                    }if(values.taxAmt == 0) {
                errors.taxAmt = "Required"
                    }if(values.totalDue == 0) {
                errors.totalDue = "Required"
                    }if(values.vendorID == 0) {
                errors.vendorID = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new PurchaseOrderHeaderMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.PurchaseOrderHeaders +'/' + values.purchaseOrderID,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.PurchaseOrderHeaderClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
        }, 
		error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
        .then(response =>
        {
            // cleanup
        })
    },
  
    displayName: 'PurchaseOrderHeaderEdit', 
  })(PurchaseOrderHeaderEditDisplay);

 
  interface IParams 
  {
     purchaseOrderID:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface PurchaseOrderHeaderEditComponentProps
  {
     match:IMatch;
  }

  interface PurchaseOrderHeaderEditComponentState
  {
      model?:PurchaseOrderHeaderViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class PurchaseOrderHeaderEditComponent extends React.Component<PurchaseOrderHeaderEditComponentProps, PurchaseOrderHeaderEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.PurchaseOrderHeaders + '/' + this.props.match.params.purchaseOrderID, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.PurchaseOrderHeaderClientResponseModel;
            
            console.log(response);

			let mapper = new PurchaseOrderHeaderMapper();

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, 
		error => {
            console.log(error);
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
        })
    }
    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
        else if (this.state.errorOccurred) {
			return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<PurchaseOrderHeaderEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>27376f9a02823fc7418d3f0da00daf69</Hash>
</Codenesium>*/