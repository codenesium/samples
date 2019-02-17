import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import SaleViewModel from './saleViewModel';
import SaleMapper from './saleMapper';

interface Props {
    model?:SaleViewModel
}

  const SaleEditDisplay = (props: FormikProps<SaleViewModel>) => {

   let status = props.status as UpdateResponse<Api.SaleClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof SaleViewModel]  && props.errors[name as keyof SaleViewModel]) {
            response += props.errors[name as keyof SaleViewModel];
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
                        <label htmlFor="name" className={errorExistForField("id") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Id</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="id" className={errorExistForField("id") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("id") && <small className="text-danger">{errorsForField("id")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("ipAddress") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>IpAddress</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="ipAddress" className={errorExistForField("ipAddress") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("ipAddress") && <small className="text-danger">{errorsForField("ipAddress")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("note") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Notes</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="note" className={errorExistForField("note") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("note") && <small className="text-danger">{errorsForField("note")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("saleDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>SaleDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="saleDate" className={errorExistForField("saleDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("saleDate") && <small className="text-danger">{errorsForField("saleDate")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("transactionId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TransactionId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="transactionId" className={errorExistForField("transactionId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("transactionId") && <small className="text-danger">{errorsForField("transactionId")}</small>}
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


const SaleEdit = withFormik<Props, SaleViewModel>({
    mapPropsToValues: props => {
        let response = new SaleViewModel();
		response.setProperties(props.model!.id,props.model!.ipAddress,props.model!.note,props.model!.saleDate,props.model!.transactionId);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<SaleViewModel> = { };

	  if(values.id == 0) {
                errors.id = "Required"
                    }if(values.ipAddress == '') {
                errors.ipAddress = "Required"
                    }if(values.note == '') {
                errors.note = "Required"
                    }if(values.saleDate == undefined) {
                errors.saleDate = "Required"
                    }if(values.transactionId == 0) {
                errors.transactionId = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new SaleMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.Sales +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.SaleClientRequestModel>;
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
  
    displayName: 'SaleEdit', 
  })(SaleEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface SaleEditComponentProps
  {
     match:IMatch;
  }

  interface SaleEditComponentState
  {
      model?:SaleViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class SaleEditComponent extends React.Component<SaleEditComponentProps, SaleEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Sales + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.SaleClientResponseModel;
            
            console.log(response);

			let mapper = new SaleMapper();

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
            return (<SaleEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>68a610596788b9ec43211f11a02e9cfd</Hash>
</Codenesium>*/