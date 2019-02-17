import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import TransactionViewModel from './transactionViewModel';
import TransactionMapper from './transactionMapper';

interface Props {
    model?:TransactionViewModel
}

  const TransactionEditDisplay = (props: FormikProps<TransactionViewModel>) => {

   let status = props.status as UpdateResponse<Api.TransactionClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof TransactionViewModel]  && props.errors[name as keyof TransactionViewModel]) {
            response += props.errors[name as keyof TransactionViewModel];
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
                        <label htmlFor="name" className={errorExistForField("amount") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Amount</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="amount" className={errorExistForField("amount") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("amount") && <small className="text-danger">{errorsForField("amount")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("gatewayConfirmationNumber") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>GatewayConfirmationNumber</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="gatewayConfirmationNumber" className={errorExistForField("gatewayConfirmationNumber") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("gatewayConfirmationNumber") && <small className="text-danger">{errorsForField("gatewayConfirmationNumber")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("id") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Id</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="id" className={errorExistForField("id") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("id") && <small className="text-danger">{errorsForField("id")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("transactionStatusId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TransactionStatusId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="transactionStatusId" className={errorExistForField("transactionStatusId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("transactionStatusId") && <small className="text-danger">{errorsForField("transactionStatusId")}</small>}
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


const TransactionEdit = withFormik<Props, TransactionViewModel>({
    mapPropsToValues: props => {
        let response = new TransactionViewModel();
		response.setProperties(props.model!.amount,props.model!.gatewayConfirmationNumber,props.model!.id,props.model!.transactionStatusId);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<TransactionViewModel> = { };

	  if(values.amount == 0) {
                errors.amount = "Required"
                    }if(values.gatewayConfirmationNumber == '') {
                errors.gatewayConfirmationNumber = "Required"
                    }if(values.id == 0) {
                errors.id = "Required"
                    }if(values.transactionStatusId == 0) {
                errors.transactionStatusId = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new TransactionMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.Transactions +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.TransactionClientRequestModel>;
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
  
    displayName: 'TransactionEdit', 
  })(TransactionEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface TransactionEditComponentProps
  {
     match:IMatch;
  }

  interface TransactionEditComponentState
  {
      model?:TransactionViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class TransactionEditComponent extends React.Component<TransactionEditComponentProps, TransactionEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Transactions + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.TransactionClientResponseModel;
            
            console.log(response);

			let mapper = new TransactionMapper();

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
            return (<TransactionEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>daa6c2987f45b4b4ea8a785fba6c4e45</Hash>
</Codenesium>*/