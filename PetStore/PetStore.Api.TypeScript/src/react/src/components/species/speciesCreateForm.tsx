import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import SpeciesMapper from './speciesMapper';
import SpeciesViewModel from './speciesViewModel';

interface Props {
    model?:SpeciesViewModel
}

   const SpeciesCreateDisplay: React.SFC<FormikProps<SpeciesViewModel>> = (props: FormikProps<SpeciesViewModel>) => {

   let status = props.status as CreateResponse<Api.SpeciesClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof SpeciesViewModel]  && props.errors[name as keyof SpeciesViewModel]) {
            response += props.errors[name as keyof SpeciesViewModel];
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
          </form>);
}


const SpeciesCreate = withFormik<Props, SpeciesViewModel>({
    mapPropsToValues: props => {
                
		let response = new SpeciesViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.id,props.model!.name);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<SpeciesViewModel> = { };

	  if(values.name == '') {
                errors.name = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new SpeciesMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Species,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.SpeciesClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'SpeciesCreate', 
  })(SpeciesCreateDisplay);

  interface SpeciesCreateComponentProps
  {
  }

  interface SpeciesCreateComponentState
  {
      model?:SpeciesViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class SpeciesCreateComponent extends React.Component<SpeciesCreateComponentProps, SpeciesCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<SpeciesCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>f923429d4a4939dd2fcf1971fdbf8343</Hash>
</Codenesium>*/