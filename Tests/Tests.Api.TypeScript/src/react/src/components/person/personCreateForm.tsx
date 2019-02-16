import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import PersonMapper from './personMapper';
import PersonViewModel from './personViewModel';

interface Props {
    model?:PersonViewModel
}

   const PersonCreateDisplay: React.SFC<FormikProps<PersonViewModel>> = (props: FormikProps<PersonViewModel>) => {

   let status = props.status as CreateResponse<Api.PersonClientRequestModel>;
   
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

   return (<form onSubmit={props.handleSubmit} role="form">            
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
          </form>);
}


const PersonCreate = withFormik<Props, PersonViewModel>({
    mapPropsToValues: props => {
                
		let response = new PersonViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.personId,props.model!.personName);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<PersonViewModel> = { };

	  if(values.personName == '') {
                errors.personName = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new PersonMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.People,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.PersonClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'PersonCreate', 
  })(PersonCreateDisplay);

  interface PersonCreateComponentProps
  {
  }

  interface PersonCreateComponentState
  {
      model?:PersonViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class PersonCreateComponent extends React.Component<PersonCreateComponentProps, PersonCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<PersonCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>8571ba2419501dc39536c2f27207ed75</Hash>
</Codenesium>*/