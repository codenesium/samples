import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import PaymentTypeViewModel from './paymentTypeViewModel';
import PaymentTypeMapper from './paymentTypeMapper';

interface Props {
    model?:PaymentTypeViewModel
}

  const PaymentTypeEditDisplay = (props: FormikProps<PaymentTypeViewModel>) => {

   let status = props.status as UpdateResponse<Api.PaymentTypeClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof PaymentTypeViewModel]  && props.errors[name as keyof PaymentTypeViewModel]) {
            response += props.errors[name as keyof PaymentTypeViewModel];
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
                        <label htmlFor="name" className={errorExistForField("name") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Name</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="name" className={errorExistForField("name") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("name") && <small className="text-danger">{errorsForField("name")}</small>}
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


const PaymentTypeEdit = withFormik<Props, PaymentTypeViewModel>({
    mapPropsToValues: props => {
        let response = new PaymentTypeViewModel();
		response.setProperties(props.model!.id,props.model!.name);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<PaymentTypeViewModel> = { };

	  if(values.id == 0) {
                errors.id = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new PaymentTypeMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.PaymentTypes +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.PaymentTypeClientRequestModel>;
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
  
    displayName: 'PaymentTypeEdit', 
  })(PaymentTypeEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface PaymentTypeEditComponentProps
  {
     match:IMatch;
  }

  interface PaymentTypeEditComponentState
  {
      model?:PaymentTypeViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class PaymentTypeEditComponent extends React.Component<PaymentTypeEditComponentProps, PaymentTypeEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.PaymentTypes + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.PaymentTypeClientResponseModel;
            
            console.log(response);

			let mapper = new PaymentTypeMapper();

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
            return (<PaymentTypeEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>19d3191618390387633e135e8ebdd27e</Hash>
</Codenesium>*/