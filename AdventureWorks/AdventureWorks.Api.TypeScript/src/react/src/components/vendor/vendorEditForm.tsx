import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import VendorViewModel from './vendorViewModel';
import VendorMapper from './vendorMapper';

interface Props {
    model?:VendorViewModel
}

  const VendorEditDisplay = (props: FormikProps<VendorViewModel>) => {

   let status = props.status as UpdateResponse<Api.VendorClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof VendorViewModel]  && props.errors[name as keyof VendorViewModel]) {
            response += props.errors[name as keyof VendorViewModel];
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
                        <label htmlFor="name" className={errorExistForField("accountNumber") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>AccountNumber</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="accountNumber" className={errorExistForField("accountNumber") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("accountNumber") && <small className="text-danger">{errorsForField("accountNumber")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("activeFlag") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ActiveFlag</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="activeFlag" className={errorExistForField("activeFlag") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("activeFlag") && <small className="text-danger">{errorsForField("activeFlag")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("businessEntityID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>BusinessEntityID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="businessEntityID" className={errorExistForField("businessEntityID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("businessEntityID") && <small className="text-danger">{errorsForField("businessEntityID")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("creditRating") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CreditRating</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="creditRating" className={errorExistForField("creditRating") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("creditRating") && <small className="text-danger">{errorsForField("creditRating")}</small>}
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
                        <label htmlFor="name" className={errorExistForField("name") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Name</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="name" className={errorExistForField("name") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("name") && <small className="text-danger">{errorsForField("name")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("preferredVendorStatu") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PreferredVendorStatus</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="preferredVendorStatu" className={errorExistForField("preferredVendorStatu") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("preferredVendorStatu") && <small className="text-danger">{errorsForField("preferredVendorStatu")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("purchasingWebServiceURL") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PurchasingWebServiceURL</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="purchasingWebServiceURL" className={errorExistForField("purchasingWebServiceURL") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("purchasingWebServiceURL") && <small className="text-danger">{errorsForField("purchasingWebServiceURL")}</small>}
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


const VendorEdit = withFormik<Props, VendorViewModel>({
    mapPropsToValues: props => {
        let response = new VendorViewModel();
		response.setProperties(props.model!.accountNumber,props.model!.activeFlag,props.model!.businessEntityID,props.model!.creditRating,props.model!.modifiedDate,props.model!.name,props.model!.preferredVendorStatu,props.model!.purchasingWebServiceURL);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<VendorViewModel> = { };

	  if(values.accountNumber == '') {
                errors.accountNumber = "Required"
                    }if(values.businessEntityID == 0) {
                errors.businessEntityID = "Required"
                    }if(values.creditRating == 0) {
                errors.creditRating = "Required"
                    }if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new VendorMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.Vendors +'/' + values.businessEntityID,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.VendorClientRequestModel>;
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
  
    displayName: 'VendorEdit', 
  })(VendorEditDisplay);

 
  interface IParams 
  {
     businessEntityID:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface VendorEditComponentProps
  {
     match:IMatch;
  }

  interface VendorEditComponentState
  {
      model?:VendorViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class VendorEditComponent extends React.Component<VendorEditComponentProps, VendorEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Vendors + '/' + this.props.match.params.businessEntityID, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.VendorClientResponseModel;
            
            console.log(response);

			let mapper = new VendorMapper();

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
            return (<VendorEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>e4da5c10793828556c8ba5df8f29793e</Hash>
</Codenesium>*/