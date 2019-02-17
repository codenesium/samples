import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import IllustrationMapper from './illustrationMapper';
import IllustrationViewModel from './illustrationViewModel';

interface Props {
    model?:IllustrationViewModel
}

   const IllustrationCreateDisplay: React.SFC<FormikProps<IllustrationViewModel>> = (props: FormikProps<IllustrationViewModel>) => {

   let status = props.status as CreateResponse<Api.IllustrationClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof IllustrationViewModel]  && props.errors[name as keyof IllustrationViewModel]) {
            response += props.errors[name as keyof IllustrationViewModel];
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
                        <label htmlFor="name" className={errorExistForField("diagram") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Diagram</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="diagram" className={errorExistForField("diagram") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("diagram") && <small className="text-danger">{errorsForField("diagram")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("modifiedDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ModifiedDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="modifiedDate" className={errorExistForField("modifiedDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("modifiedDate") && <small className="text-danger">{errorsForField("modifiedDate")}</small>}
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


const IllustrationCreate = withFormik<Props, IllustrationViewModel>({
    mapPropsToValues: props => {
                
		let response = new IllustrationViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.diagram,props.model!.illustrationID,props.model!.modifiedDate);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<IllustrationViewModel> = { };

	  if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new IllustrationMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Illustrations,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.IllustrationClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'IllustrationCreate', 
  })(IllustrationCreateDisplay);

  interface IllustrationCreateComponentProps
  {
  }

  interface IllustrationCreateComponentState
  {
      model?:IllustrationViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class IllustrationCreateComponent extends React.Component<IllustrationCreateComponentProps, IllustrationCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<IllustrationCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>a41236d390b414e400629b9e86a9abf9</Hash>
</Codenesium>*/