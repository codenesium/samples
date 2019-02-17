import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import CountryRegionViewModel from './countryRegionViewModel';
import CountryRegionMapper from './countryRegionMapper';

interface Props {
    model?:CountryRegionViewModel
}

  const CountryRegionEditDisplay = (props: FormikProps<CountryRegionViewModel>) => {

   let status = props.status as UpdateResponse<Api.CountryRegionClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof CountryRegionViewModel]  && props.errors[name as keyof CountryRegionViewModel]) {
            response += props.errors[name as keyof CountryRegionViewModel];
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
                        <label htmlFor="name" className={errorExistForField("countryRegionCode") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CountryRegionCode</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="countryRegionCode" className={errorExistForField("countryRegionCode") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("countryRegionCode") && <small className="text-danger">{errorsForField("countryRegionCode")}</small>}
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


const CountryRegionEdit = withFormik<Props, CountryRegionViewModel>({
    mapPropsToValues: props => {
        let response = new CountryRegionViewModel();
		response.setProperties(props.model!.countryRegionCode,props.model!.modifiedDate,props.model!.name);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<CountryRegionViewModel> = { };

	  if(values.countryRegionCode == '') {
                errors.countryRegionCode = "Required"
                    }if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new CountryRegionMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.CountryRegions +'/' + values.countryRegionCode,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.CountryRegionClientRequestModel>;
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
  
    displayName: 'CountryRegionEdit', 
  })(CountryRegionEditDisplay);

 
  interface IParams 
  {
     countryRegionCode:string;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface CountryRegionEditComponentProps
  {
     match:IMatch;
  }

  interface CountryRegionEditComponentState
  {
      model?:CountryRegionViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class CountryRegionEditComponent extends React.Component<CountryRegionEditComponentProps, CountryRegionEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.CountryRegions + '/' + this.props.match.params.countryRegionCode, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.CountryRegionClientResponseModel;
            
            console.log(response);

			let mapper = new CountryRegionMapper();

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
            return (<CountryRegionEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>d4af3ec7ce0aff6018abd373cb0843d0</Hash>
</Codenesium>*/