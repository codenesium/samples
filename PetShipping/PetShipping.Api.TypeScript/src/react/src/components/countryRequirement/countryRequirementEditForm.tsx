import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import CountryRequirementViewModel from './countryRequirementViewModel';
import CountryRequirementMapper from './countryRequirementMapper';

interface Props {
    model?:CountryRequirementViewModel
}

  const CountryRequirementEditDisplay = (props: FormikProps<CountryRequirementViewModel>) => {

   let status = props.status as UpdateResponse<Api.CountryRequirementClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof CountryRequirementViewModel]  && props.errors[name as keyof CountryRequirementViewModel]) {
            response += props.errors[name as keyof CountryRequirementViewModel];
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
                        <label htmlFor="name" className={errorExistForField("countryId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CountryId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="countryId" className={errorExistForField("countryId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("countryId") && <small className="text-danger">{errorsForField("countryId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("detail") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Details</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="detail" className={errorExistForField("detail") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("detail") && <small className="text-danger">{errorsForField("detail")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("id") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Id</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="id" className={errorExistForField("id") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("id") && <small className="text-danger">{errorsForField("id")}</small>}
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


const CountryRequirementEdit = withFormik<Props, CountryRequirementViewModel>({
    mapPropsToValues: props => {
        let response = new CountryRequirementViewModel();
		response.setProperties(props.model!.countryId,props.model!.detail,props.model!.id);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<CountryRequirementViewModel> = { };

	  if(values.countryId == 0) {
                errors.countryId = "Required"
                    }if(values.detail == '') {
                errors.detail = "Required"
                    }if(values.id == 0) {
                errors.id = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new CountryRequirementMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.CountryRequirements +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.CountryRequirementClientRequestModel>;
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
  
    displayName: 'CountryRequirementEdit', 
  })(CountryRequirementEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface CountryRequirementEditComponentProps
  {
     match:IMatch;
  }

  interface CountryRequirementEditComponentState
  {
      model?:CountryRequirementViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class CountryRequirementEditComponent extends React.Component<CountryRequirementEditComponentProps, CountryRequirementEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.CountryRequirements + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.CountryRequirementClientResponseModel;
            
            console.log(response);

			let mapper = new CountryRequirementMapper();

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
            return (<CountryRequirementEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>44cbbd1e4a8ee44136f2a633040d4448</Hash>
</Codenesium>*/