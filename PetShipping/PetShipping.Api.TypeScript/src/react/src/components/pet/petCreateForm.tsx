import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import PetMapper from './petMapper';
import PetViewModel from './petViewModel';

interface Props {
    model?:PetViewModel
}

   const PetCreateDisplay: React.SFC<FormikProps<PetViewModel>> = (props: FormikProps<PetViewModel>) => {

   let status = props.status as CreateResponse<Api.PetClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof PetViewModel]  && props.errors[name as keyof PetViewModel]) {
            response += props.errors[name as keyof PetViewModel];
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
                        <label htmlFor="name" className={errorExistForField("breedId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>BreedId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="breedId" className={errorExistForField("breedId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("breedId") && <small className="text-danger">{errorsForField("breedId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("clientId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ClientId</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="clientId" className={errorExistForField("clientId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("clientId") && <small className="text-danger">{errorsForField("clientId")}</small>}
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
                        <label htmlFor="name" className={errorExistForField("weight") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Weight</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="weight" className={errorExistForField("weight") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("weight") && <small className="text-danger">{errorsForField("weight")}</small>}
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


const PetCreate = withFormik<Props, PetViewModel>({
    mapPropsToValues: props => {
                
		let response = new PetViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.breedId,props.model!.clientId,props.model!.id,props.model!.name,props.model!.weight);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<PetViewModel> = { };

	  if(values.breedId == 0) {
                errors.breedId = "Required"
                    }if(values.clientId == 0) {
                errors.clientId = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }if(values.weight == 0) {
                errors.weight = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new PetMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Pets,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.PetClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'PetCreate', 
  })(PetCreateDisplay);

  interface PetCreateComponentProps
  {
  }

  interface PetCreateComponentState
  {
      model?:PetViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class PetCreateComponent extends React.Component<PetCreateComponentProps, PetCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<PetCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>f702bb0cd9c9751ab55ee207f098a2ba</Hash>
</Codenesium>*/