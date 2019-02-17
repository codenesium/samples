import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import PersonViewModel from './personViewModel';
import PersonMapper from './personMapper';

interface Props {
    model?:PersonViewModel
}

  const PersonEditDisplay = (props: FormikProps<PersonViewModel>) => {

   let status = props.status as UpdateResponse<Api.PersonClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof PersonViewModel]  && props.errors[name as keyof PersonViewModel]) {
            response += props.errors[name as keyof PersonViewModel];
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
                        <label htmlFor="name" className={errorExistForField("personId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PersonId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="personId" className={errorExistForField("personId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("personId") && <small className="text-danger">{errorsForField("personId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("personName") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PersonName</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="personName" className={errorExistForField("personName") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("personName") && <small className="text-danger">{errorsForField("personName")}</small>}
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


const PersonEdit = withFormik<Props, PersonViewModel>({
    mapPropsToValues: props => {
        let response = new PersonViewModel();
		response.setProperties(props.model!.personId,props.model!.personName);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<PersonViewModel> = { };

	  if(values.personId == 0) {
                errors.personId = "Required"
                    }if(values.personName == '') {
                errors.personName = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new PersonMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.People +'/' + values.personId,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.PersonClientRequestModel>;
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
  
    displayName: 'PersonEdit', 
  })(PersonEditDisplay);

 
  interface IParams 
  {
     personId:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface PersonEditComponentProps
  {
     match:IMatch;
  }

  interface PersonEditComponentState
  {
      model?:PersonViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class PersonEditComponent extends React.Component<PersonEditComponentProps, PersonEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.People + '/' + this.props.match.params.personId, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.PersonClientResponseModel;
            
            console.log(response);

			let mapper = new PersonMapper();

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
            return (<PersonEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>51807d83ceee03a7dfd6bbae7dc6823f</Hash>
</Codenesium>*/